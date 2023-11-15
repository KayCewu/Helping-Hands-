using Helping_Hands_2._0.Models;
using Helping_Hands_2._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helping_Hands_2._0.Controllers
{
    public class ConditionsController : Controller
    {
        private IConditionsService _conditions;
        public ConditionsController(IConditionsService con)
        {
            _conditions = con;
        }
        public IActionResult Index()
        {
            var Conditions = _conditions.GetConditions();
            return View(Conditions);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult MemberCons()
        {
            string Email = User.Identity.Name;
            var Conditions = _conditions.MyChronicConditions(Email);
            return View(Conditions);
        }
        [HttpPost]
        public IActionResult Create(ChronicCondition chronicCondition){
            if (ModelState.IsValid)
            {
                _conditions.AddCondition(chronicCondition);
            }
            return RedirectToAction("Index", "Conditions");
        }
        public IActionResult Delete(int Id)
        {
            _conditions.Delete(Id);
            return RedirectToAction("Index", "Conditions");
        }
        
    }
}
