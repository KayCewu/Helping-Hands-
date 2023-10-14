using Helping_Hands_2._0.Models;
using Helping_Hands_2._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helping_Hands_2._0.Controllers
{
    public class ProfileController : Controller
    {
        public IPatientService _ps;
        public ProfileController(IPatientService ps)
        {
            _ps = ps;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PatientProfile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PatientProfile(Patient p)
        {
           if (ModelState.IsValid)
            {
                _ps.AddPatient(p);
                return View();
            }
            return View();
        }
    }
}
