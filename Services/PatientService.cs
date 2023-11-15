using Helping_Hands_2._0.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Helping_Hands_2._0.Services
{
    public class PatientService : IPatientService, IDisposable
    {

        private readonly HelpingHandsDbContext _context;
        public PatientService(HelpingHandsDbContext db)
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

        public void AddPatient(Patient patient)
        {
            _context.Add(patient);
            _context.SaveChanges();
        }

        public List<string> LoadSuburbs()
        {
            var suburbList = _context.Suburbs.Select(s => s.SuburbName).ToList();
            //var suburbList = _context.Suburbs.Select(s => new SelectListItem { Value = s.SuburbId.ToString(), Text = s.SuburbName }).ToList();
            //var model = new Patient()
            //{
            //    Suburb = suburbList
            //};
            return suburbList;
            //model.Suburb = new SelectList(suburbs);
            //ViewBag.SuburbList = new SelectList(dbContext.Suburbs, "Id", "Name");
            
            //return View(model);
        }
    }
}
