using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TSTB.DAL.Models.Ip;
using TSTB.DAL.Models.Language;
using TSTB.DAL.Models.Settings;
using TSTB.DAL.Models.User;
using TSTB.Web.Data;

namespace TSTB.DAL.Data
{
    public static class CreateAdminData
    {
        public async static Task CreateDataTask(IHost host)
        {
            IWebHostEnvironment _env = host.Services.GetService<IWebHostEnvironment>();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var _dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await _dbContext.Database.MigrateAsync();
                var context = services.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await context.Roles.AnyAsync())
                {
                    await context.CreateAsync(new IdentityRole
                    {
                        Name = "Admin"
                    });
                    await context.CreateAsync(new IdentityRole
                    {
                        Name = "Entrepreneur"
                    });
                    await context.CreateAsync(new IdentityRole
                    {
                        Name = "Registration-Manager"
                    });
                    await context.CreateAsync(new IdentityRole
                    {
                        Name = "Accountant"
                    });
                    await context.CreateAsync(new IdentityRole
                    {
                        Name = "Content-Manager"
                    });
                }

                var userContext = services.GetRequiredService<UserManager<ApplicationUser>>();

                var admin = await userContext.FindByNameAsync("Admin");

                if (admin == null)
                {
                    ApplicationUser adminUser = new ApplicationUser
                    {
                        FirstName = "Admin",
                        LastName = "TSTB",
                        Email = $"admin@tstb.gov.tm",
                        UserName = "Admin",
                        EmailConfirmed = true
                    };

                    await userContext.CreateAsync(adminUser, "Password!1");
                    await userContext.AddToRoleAsync(adminUser, "Admin");
                }

                List<Language> languages = new List<Language>();
                languages.Add(new Language() { Culture = "ru", Name = "Русский", DisplayOrder = 0, IsPublish = true });
                languages.Add(new Language() { Culture = "en", Name = "English", DisplayOrder = 1, IsPublish = true });
                languages.Add(new Language() { Culture = "tk", Name = "Türkmençe", DisplayOrder = 2, IsPublish = true });

                

                foreach (var lng in languages)
                {
                    var language = await _dbContext.Languages.SingleOrDefaultAsync(s => s.Culture == lng.Culture);
                    if (language == null)
                    {
                        _dbContext.Languages.Add(lng);
                        await _dbContext.SaveChangesAsync();
                    }
                }

                List<Settings> settings = new List<Settings>();
                settings.Add(new Settings() { Name = "returnUrl", Value = "https://localhost:5001/Employee/Payment/SuccessView" });
                settings.Add(new Settings() { Name = "failUrl", Value = "https://localhost:5001/Employee/Payment/FailView" });
                settings.Add(new Settings() { Name = "userName", Value = "tstbAPI" });
                settings.Add(new Settings() { Name = "password", Value = "tstbAPI@2020" });
                settings.Add(new Settings() { Name = "currency", Value = "934" });
                settings.Add(new Settings() { Name = "language", Value = "ru" });
                settings.Add(new Settings() { Name = "pageView", Value = "Desktop" });
                settings.Add(new Settings() { Name = "bankUrl", Value = "https://agn.rysgalbank.tm/epg/rest/register.do" });
                settings.Add(new Settings() { Name = "bankUrlCheck", Value = "https://agn.rysgalbank.tm/epg/rest/getOrderStatusExtended.do" });
                settings.Add(new Settings() { Name = "returnUrlCharity", Value = "https://localhost:5001/Employee/Charity/SuccessView" });
                settings.Add(new Settings() { Name = "failUrlCharity", Value = "https://localhost:5001/Employee/Charity/FailView" });
                settings.Add(new Settings() { Name = "AdminEmail", Value = "info@tstb.gov.tm" });
                settings.Add(new Settings() { Name = "AdminEmailPassword", Value = "Password!1" }); 
                settings.Add(new Settings() { Name = "UnsubLink", Value = "https://localhost:5001/Home/UnsubLink" });
                settings.Add(new Settings() { Name = "UnsubscribeLink", Value = "https://localhost:5001/Home/Unsubscribe" });
                settings.Add(new Settings() { Name = "PhoneSPPT", Value = "+99312-21-23-44 <br /> +99312-21-23-45" });
                settings.Add(new Settings() { Name = "AddressSPPT", Value = "пр. А.Ниязова 174, Ашхабат, <br /> Туркменистан, 744013" });
                settings.Add(new Settings() { Name = "EmailSPPT", Value = "info@tstb.gov.tm" });
                settings.Add(new Settings() { Name = "Entreprenuers", Value = "24510" });
                settings.Add(new Settings() { Name = "Years_with_you", Value = "12" });
                settings.Add(new Settings() { Name = "Completed_projects", Value = "2265" });
                settings.Add(new Settings() { Name = "Trained_Entreprenuers", Value = "80300" });

                foreach (var setting in settings)
                {
                    var stng = await _dbContext.Settings.SingleOrDefaultAsync(s => s.Name == setting.Name);
                    if(stng == null)
                    {
                        _dbContext.Settings.Add(setting);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
           
        }
    }
}
