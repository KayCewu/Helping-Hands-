using Helping_Hands_2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;

namespace Helping_Hands_2._0.Services
{
    public class ConditionsService: IConditionsService, IDisposable
    {
        private readonly HelpingHandsDbContext _context;
        public ConditionsService(HelpingHandsDbContext db)
        {
            _context= db;
        }

        public void AddCondition(ChronicCondition condition)
        {
            if (condition != null)
            {
                _context.ChronicConditions.Add(condition);
                _context.SaveChanges();
            }
            
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

        public List<ChronicCondition> GetConditions()
        {
            var conditions = _context.ChronicConditions.ToList();
            return conditions;
        }

        public void Delete(int ID)
        {
            if (ID >0)
            {
                var exists = _context.ChronicConditions.Where(x => x.ChronicId == ID).FirstOrDefault();
                if (exists != null)
                {
                    _context.Remove(exists);
                    _context.SaveChanges();
                }
            }
        }

        public IEnumerable<PatientChronicCon> MyChronicConditions(string Email)
        {
            int userid = _context.Users.Where(x => x.Email == Email).Select(x => x.Id).FirstOrDefault();
            var chroniccons = _context.PatientChronicCons.ToList().Where(y => y.UserId == userid);
            return chroniccons;
        }
    }
    
}
