using Dapper;
using Helping_Hands_2._0.Models;
using Helping_Hands_2._0.Models.ViewModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Helping_Hands_2._0.Services
{
    public class CareContractService : ICareContract
    {
        private readonly HelpingHandsDbContext _context;
        private readonly IConfiguration _configuration;

        public CareContractService(HelpingHandsDbContext context, IConfiguration config)
        {
            _context= context;
            _configuration= config;
        }
        public void CreateContract(CareContract careContract, string Email)
        {
            var UserId= _context.Users.Where(x => x.Email == Email).Select(x => x.Id).FirstOrDefault();
            var CStatus = "N";
            string connectionString = _configuration.GetConnectionString("ApplicationDBContextConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    var parameters = new DynamicParameters();
                    // parameters.Add("@CDate", careContract. , DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@CStatus", CStatus, DbType.String, ParameterDirection.Input);
                    parameters.Add("@CAddress", careContract.ContractAddress, DbType.String, ParameterDirection.Input);
                    parameters.Add("@StartDate", careContract.StartDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@EndDate", careContract.EndDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@WDesc", careContract.WoundDescription, DbType.String, ParameterDirection.Input);
                    parameters.Add("@PNo", UserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@CDate", careContract.ContractDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@AssignedNurse", 0, DbType.Int32, ParameterDirection.Input);
                    

                    connection.Execute("SP_CreateCareContract", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
