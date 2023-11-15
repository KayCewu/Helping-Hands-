using Helping_Hands_2._0.Models;
using Helping_Hands_2._0.Models.ViewModels;
using Helping_Hands_2._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helping_Hands_2._0.Controllers
{

    public class NurseController : Controller
    {
        public readonly INurseService _NurseService;
        public NurseController(INurseService ns)
        {
            _NurseService = ns;
        }
        public IActionResult Index()
        {
            var Nurses = _NurseService.GetNurses();
            return View(Nurses);
        }
        public IActionResult CareVisit()
        {
            return View();
        }
        public IActionResult CareContracts()
        {
            var Contracts = _NurseService.GetCareContracts();
            return View(Contracts);
        }

        public IActionResult MyCareContracts(string email)
        {
            email = User.Identity.Name; 
            var MyContracts = _NurseService.MyCareContracts(email);
            
            return View(MyContracts);
        }

        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult PreferredSuburb()
        {
            var Suburbs = _NurseService.GetSuburbs();
            return View(Suburbs);
        }
        [HttpPost]

        public IActionResult UpdateProfile(NurseUpdate Nu)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                _NurseService.UpdateNurse(Nu, userId);
            }
            return RedirectToAction("Profile", "Nurse");
        }
        public IActionResult CreateCareVisit(VisitInfo VI)
        {
            if (ModelState.IsValid)
            {
                _NurseService.CreateCareVisit(VI);
                return RedirectToAction("CareVisits", "Nurse");
            }
            return View();
        }


    }
}
