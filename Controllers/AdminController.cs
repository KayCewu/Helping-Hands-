using Helping_Hands_2._0.Areas.Identity.Pages.Account;
using Helping_Hands_2._0.Models;
using Helping_Hands_2._0.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Helping_Hands_2._0.Controllers
{
    public class AdminController : Controller
    {
        
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        
        public AdminController(IAdminService adminService, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) 
        {
           
            _roleManager = roleManager;
            _userManager = userManager;

        }
        [HttpGet]
        public IActionResult RegisterNurse()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterNurse(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.UserName, PasswordHash = model.PasswordHash, Email=model.UserName };

                var result = await _userManager.CreateAsync(user, model.PasswordHash);

                if (result.Succeeded)
                {
                    var roleName = "Nurse"; // Replace with the actual role name
                    var roleExists = await _roleManager.RoleExistsAsync(roleName);

                    if (!roleExists)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(roleName));
                    }

                    await _userManager.AddToRoleAsync(user, roleName);

                    var userId = _userManager.GetUserId(User);
                    roleName = "Patient";
                    var isInRole = await _userManager.IsInRoleAsync(user, roleName);

                    if (isInRole)
                    {
                        // Remove the user from the role
                         await _userManager.RemoveFromRoleAsync(user, roleName);
                    }

                        return RedirectToAction("Index", "Home");
                }
                
            }

            // If we got this far, something failed; redisplay the form
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
