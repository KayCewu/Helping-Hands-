using Dapper;
using Microsoft.AspNetCore.Identity;
using Helping_Hands_2._0.Models;
using Helping_Hands_2._0.Models.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using System.Linq;

namespace Helping_Hands_2._0.Services
{
    public class NurseService : INurseService, IDisposable
    {
        private readonly HelpingHandsDbContext _context;
        private readonly IConfiguration _configuration;


        public NurseService(HelpingHandsDbContext db, IConfiguration config)
        {
            _context = db;
            _configuration = config;

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public List<Nurse> GetNurses()
        {
            var Nurses = _context.Nurses.ToList();
            return Nurses;
        }

        public void CreateCareVisit(VisitInfo visit, int id)
        {
            if (visit != null)
            {
                visit.ContractNo = id;
                _context.VisitInfos.Add(visit);
                _context.SaveChanges();
            }

        }

        public List<CareContract> GetCareContracts()
        {
            var CareContract = _context.CareContracts.Where(x => x.ContractStatus == "A").ToList();
            return CareContract;
        }
        public List<CareContract> GetCareContractsOfficeManager()
        {
            var CareContract = _context.CareContracts.Where(x => x.ContractStatus == "A").ToList();
            return CareContract;
        }

        public void UpdateNurse(NurseUpdate nurseUpdate, string NurseEmail)
        {
            try
            {
                //var LoggedIn = _userManager.GetUserId(User);
                var NurseID = _context.Nurses.Where(x => x.Email == NurseEmail).Select(n => n.NurseCode).FirstOrDefault();

                string connectionString = _configuration.GetConnectionString("ApplicationDBContextConnection");

                using (var connection = new SqlConnection(connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@NURSEID", NurseID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@FName", nurseUpdate.FName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@SName", nurseUpdate.LName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@ID", nurseUpdate.IDNumber, DbType.String, ParameterDirection.Input);

                    connection.Execute("SP_UPDATENURSE", parameters, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {

            }

        }

        public List<Suburb> GetSuburbs()
        {
            var Suburbs = _context.Suburbs.ToList();
            return Suburbs;
        }

        public List<CareContract> MyCareContracts(string email)
        {
            int id = _context.Nurses.Where(x => x.Email == email).Select(n => n.NurseCode).FirstOrDefault();

            var MyContracts = _context.CareContracts.Where(x => x.AssignedNurse == id && x.ContractStatus == "A").ToList();

            return MyContracts;
        }


        public string PatientName(int id)
        {
            var PName = _context.Patients.Where(x => x.PatientId == id).Select(n => n.PatientName).FirstOrDefault();
            return PName;
        }

        public string PatientSurname(int id)
        {
            var PSurname = _context.Patients.Where(x => x.PatientId == id).Select(n => n.Surname).FirstOrDefault();
            return PSurname;
        }

        public string EmergencyPersonel(int id)
        {
            var EmergPerson = _context.Patients.Where(x => x.PatientId == id).Select(n => n.EmergencyContact).FirstOrDefault();
            return EmergPerson;
        }

        public string EmergencyContact(int id)
        {
            var EmergPersonContact = _context.Patients.Where(x => x.PatientId == id).Select(n => n.EmergencyNumber).FirstOrDefault();
            return EmergPersonContact;
        }
        public string PatientNo(int id)
        {
            var ClientNo = _context.Users.Where(x => x.Id == id).Select(n => n.ContactNo).FirstOrDefault();
            return ClientNo;
        }

        public List<String> GetNurseNameList()
        {
            var Nurses = _context.Nurses.Select(x => x.Email).ToList();
            return Nurses;
        }

        public void AssignContract(string NurseId, string ContractId)
        {
            var Nurse = _context.Nurses.Where(x => x.Email == NurseId).Select(j => j.NurseCode).FirstOrDefault();
            var careContract = _context.CareContracts.Find(ContractId);
            careContract.AssignedNurse = Nurse;


            _context.SaveChanges();
        }

        public List<VisitInfo> GetVisitInfo(string email)
        {
            int id = _context.Nurses.Where(x => x.Email == email).Select(n => n.NurseCode).FirstOrDefault();
            var MyContracts = _context.CareContracts.Where(y => y.AssignedNurse == id).ToList();
            //var MyCareVisits = _context.VisitInfos.Where(x => MyContracts.Any(contract => contract.CareContractId == x.ContractNo)).ToList();
            var contractIds = MyContracts.Select(contract => contract.CareContractId).ToList();

            // Use the retrieved IDs to filter VisitInfos
            var MyCareVisits = _context.VisitInfos
                .Where(x => contractIds.Contains(x.ContractNo))
                .ToList();
            return MyCareVisits;
        }

        public void TakeCareContract(int id, string email)
        {
            var MyId = _context.Nurses.Where(x => x.Email == email).Select(n => n.NurseCode).FirstOrDefault();
            var contract = _context.CareContracts.Where(x => x.CareContractId == id).FirstOrDefault();
            contract.ContractStatus = "A";
            contract.AssignedNurse = MyId;
            _context.SaveChanges();
        }
        public void CloseCareContract(int id, string email)
        {
            var MyId = _context.Nurses.Where(x => x.Email == email).Select(n => n.NurseCode).FirstOrDefault();
            var contract = _context.CareContracts.Where(x => x.CareContractId == id).FirstOrDefault();
            
            contract.ContractStatus = "C";
            _context.SaveChanges();
        }
    }
}
