using Helping_Hands_2._0.Models;

namespace Helping_Hands_2._0.Services
{
    public interface IPatientService: IDisposable
    {
        void AddPatient(Patient patient);
    }
}
