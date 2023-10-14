using Helping_Hands_2._0.Models;

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
    }
}
