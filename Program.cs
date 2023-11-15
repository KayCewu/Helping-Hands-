using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Helping_Hands_2._0.Areas.Identity.Data;
using Helping_Hands_2._0.Services;
using Helping_Hands_2._0.Models;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Helping_Hands_2._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("ApplicationDBContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDBContextConnection' not found.");

            builder.Services.AddDbContext<HelpingHandsDbContext>(options =>
options.UseSqlServer(connectionString));
            builder.Services.AddTransient<IEmailSender, EmailService>();



            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<HelpingHandsDbContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<INurseService, NurseService>();
            builder.Services.AddTransient<IPatientService, PatientService>();
            builder.Services.AddTransient<IConditionsService, ConditionsService>();
            builder.Services.AddTransient<ICareContract, CareContractService>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.MapRazorPages();

            app.UseRouting();
            app.UseAuthentication(); ;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}