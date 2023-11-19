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
        public IActionResult CreateCareVisit()
        {
            return View();
        }
        public IActionResult CareVisitIndex(string email)
        {
            email = User.Identity.Name;
            var MyCareVisits = _NurseService.GetVisitInfo(email);

            foreach (var x in MyCareVisits)
            {
                x.PatientName = _NurseService.PatientName(x.VisitId);
                x.PatienSurname = _NurseService.PatientSurname(x.VisitId);
                x.CellPhoneNumber = _NurseService.PatientNo(x.VisitId);

            }
            return View(MyCareVisits);
        }
        public IActionResult CareContracts()
        {
            var Contracts = _NurseService.GetCareContracts();
            return View(Contracts);
        }
        public IActionResult OfficeManagerNewContracts()
        {
            var Contracts = _NurseService.GetCareContractsOfficeManager();
            ViewBag.Nurses = _NurseService.GetNurseNameList();
            return View(Contracts);
        }
        
        public IActionResult TakeCareContract(int id, string email)
        {
            email = User.Identity.Name;
            _NurseService.TakeCareContract(id, email);
            return RedirectToAction("Index","CareContract");

        }
        
        public IActionResult CloseCareContract(int id, string email)
        {
            email = User.Identity.Name;
            _NurseService.CloseCareContract(id, email);
            return RedirectToAction("ClosedCareContracts", "CareContract");

        }


        public IActionResult MyCareContracts(string email)
        {
            email = User.Identity.Name; 
            var MyContracts = _NurseService.MyCareContracts(email);
            
            foreach(var x in MyContracts)
            {
                x.PatientName = _NurseService.PatientName(x.PatientNo);
                x.PatientSurname = _NurseService.PatientSurname(x.PatientNo);
                x.EmergencyContact = _NurseService.EmergencyPersonel(x.PatientNo);
                x.EmergencyNo= _NurseService.EmergencyContact(x.PatientNo);
                x.PhoneNumber = _NurseService.PatientNo(x.PatientNo);

            }
            
            return View(MyContracts);
        }
        public IActionResult MyCareVisits(string email)
        {
            email = User.Identity.Name;
            var MyContracts = _NurseService.MyCareContracts(email);

            foreach (var x in MyContracts)
            {
                x.PatientName = _NurseService.PatientName(x.PatientNo);
                x.PatientSurname = _NurseService.PatientSurname(x.PatientNo);
                x.EmergencyContact = _NurseService.EmergencyPersonel(x.PatientNo);
                x.EmergencyNo = _NurseService.EmergencyContact(x.PatientNo);
                x.PhoneNumber = _NurseService.PatientNo(x.PatientNo);

            }

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
        public IActionResult AssignContract(string nurseId, string careContractId)
        {
            _NurseService.AssignContract(nurseId, careContractId);
            return RedirectToAction("OfficeManagerNewContracts", "Nurse");
        }
        public IActionResult UpdateProfile(NurseUpdate Nu)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                _NurseService.UpdateNurse(Nu, userId);
            }
            return RedirectToAction("Profile", "Nurse");
        }
        [HttpPost]
        public IActionResult CreateCareVisit(VisitInfo VI, int id)
        {
            if (ModelState.IsValid)
            {
                _NurseService.CreateCareVisit(VI, id);
                return RedirectToAction("CareVisitIndex", "Nurse");
            }
            return View();
        }
        


    }
}
