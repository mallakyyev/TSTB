using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TSTB.Web.Data;
using System.Globalization;
using TSTB.Web.Extensions;
using Microsoft.AspNetCore.Localization;
using AutoMapper;
using Microsoft.Extensions.FileProviders;
using System.IO;
using TSTB.BLL.Services.ImageService;
using TSTB.DAL.Models.User;
using TSTB.BLL.DTOs.ApplicationUserModelDTO;
using TSTB.DAL.Models.Departments;
using TSTB.BLL.DTOs.DepartmentModelDTO;
using TSTB.BLL.Services.Departments;
using TSTB.BLL.Services.Language;
using TSTB.DAL.Models.Language;
using TSTB.BLL.DTOs.LanguageDTO;
using System.Web.Mvc;
using Microsoft.AspNetCore.HttpOverrides;
using Hangfire;
using Hangfire.PostgreSql;
using TSTB.Web.Models;

namespace TSTB.Web
{
    public class Startup
    {
        public static string WebRootPath { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static string MapPath(string path, string basePath = null)
        {
            if (string.IsNullOrEmpty(basePath))
            {
                basePath = WebRootPath;
            }

            path = path.Replace("~/", "").TrimStart('/').Replace('/', '\\');
            return Path.Combine(basePath, path);
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient );
            services.AddHangfire(config =>
                 config.UsePostgreSqlStorage(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMemoryCache();

         //   services.Configure<ForwardedHeadersOptions>(options => options.ForwardedHeaders =
         //ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto);

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.Password.RequiredLength = 7;
                options.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
                options.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                options.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                options.Password.RequireDigit = false; // требуются ли цифры
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddRepositories();

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddControllersWithViews()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(SharedResource));
                })
                .AddRazorRuntimeCompilation()
                .AddViewLocalization();

         
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("ru"),
                    new CultureInfo("en"),
                    new CultureInfo("tk")
                };

                foreach (var culture in supportedCultures)
                {
                    culture.NumberFormat.NumberDecimalSeparator = ".";
                }

                options.DefaultRequestCulture = new RequestCulture("ru");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
              
            });
            

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor,

                    // IIS is also tagging a X-Forwarded-For header on, so we need to increase this limit, 
                    // otherwise the X-Forwarded-For we are passing along from the browser will be ignored
                    ForwardLimit = 2
                });
                app.UseHangfireServer();
                app.UseHangfireDashboard();
                app.UseDeveloperExceptionPage();
                
                app.UseDatabaseErrorPage();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new [] {new HangfireDashboardAuthorization()}
            });
            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                WorkerCount = 1,
            }); 

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRequestLocalization();
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 0});
            HangfireJobScheduler.ScheduleRecurringJobs();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "areas",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapAreaControllerRoute(
                    name: "areas",
                    areaName: "Employee",
                    pattern: "Employee/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                              name: "areas",
                              areaName: "Search",
                              pattern: "Search/{controller=Search}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            WebRootPath = env.WebRootPath; 
        }
    }
}
