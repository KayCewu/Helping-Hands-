using Helping_Hands_2._0.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Helping_Hands_2._0.Services
{
    public class NurseService : INurseService, IDisposable
    {
        private readonly HelpingHandsDbContext _context;
        public NurseService(HelpingHandsDbContext db)
        {
            _context = db;
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
            var Nurses= _context.Nurses.ToList();
            return Nurses;
        }

        public void CreateCareVisit(VisitInfo visit)
        {
            if (visit!=null)
            {
                _context.VisitInfos.Add(visit);
                _context.SaveChanges();
            }
           
        }

        public List<CareContract> GetCareContracts()
        {
           var CareContract= _context.CareContracts.ToList();
            return CareContract;
        }
    }
}
