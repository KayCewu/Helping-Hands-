using Helping_Hands_2._0.Areas.Identity.Data;
using Helping_Hands_2._0.Areas.Identity.Pages.Account;
using Helping_Hands_2._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Helping_Hands_2._0.Services
{
    public class AdminService:IAdminService
    {
        private readonly HelpingHandsDbContext _context;
       
        public AdminService(HelpingHandsDbContext context)
        {
            _context = context;
            

        }

        public void RemovePatientRole(Register model)
        {
            
        }
    }
}
