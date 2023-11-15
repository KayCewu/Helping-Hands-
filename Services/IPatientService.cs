using Helping_Hands_2._0.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Helping_Hands_2._0.Services
{
    public interface IPatientService: IDisposable
    {
        void AddPatient(Patient patient);
        List<string> LoadSuburbs();
        
    }
}
