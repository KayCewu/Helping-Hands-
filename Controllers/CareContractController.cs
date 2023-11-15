﻿using Helping_Hands_2._0.Models;
using Helping_Hands_2._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helping_Hands_2._0.Controllers
{
    public class CareContractController : Controller
    {
        private ICareContract _careContract;
        public CareContractController(ICareContract careContract)
        {
            _careContract= careContract;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateCareContract()
        {
                   
            return View();
        }

        [HttpPost]
        public IActionResult CreateCareContract(CareContract cc, string Email)
        {
            cc.ContractDate= DateTime.Today;
            Email = User.Identity.Name;
            _careContract.CreateContract(cc,Email);
            return View(cc);
        }
    }
}
