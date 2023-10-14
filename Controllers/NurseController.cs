using Helping_Hands_2._0.Models;
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
        [HttpPost]
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
