using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models;
using TSTB.DAL.Models.Advertisement;
using TSTB.DAL.Models.Banner;
using TSTB.DAL.Models.Billing;
using TSTB.DAL.Models.CallBacks;
using TSTB.DAL.Models.Charity;
using TSTB.DAL.Models.CurrencyRate;
using TSTB.DAL.Models.Departments;
using TSTB.DAL.Models.Email;
using TSTB.DAL.Models.Industry;
using TSTB.DAL.Models.Ip;
using TSTB.DAL.Models.Language;
using TSTB.DAL.Models.MembershipRequest;
using TSTB.DAL.Models.Menu;
using TSTB.DAL.Models.NativeProduction;
using TSTB.DAL.Models.News;
using TSTB.DAL.Models.NewsPapers;
using TSTB.DAL.Models.OnlineTrade;
using TSTB.DAL.Models.Partners;
using TSTB.DAL.Models.Projects;
using TSTB.DAL.Models.Representatives;
using TSTB.DAL.Models.Sayings;
using TSTB.DAL.Models.Services;
using TSTB.DAL.Models.Settings;
using TSTB.DAL.Models.TradingHouse;
using TSTB.DAL.Models.User;
using TSTB.DAL.Models.Widget;
using pages = TSTB.DAL.Models.Menu.Pages;

namespace TSTB.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<CallBack> CallBacks { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<CitiesTranslate> CitiesTranslates { get; set; }

        public DbSet<Departments> Departments { get; set; }
        public DbSet<DepartmentsTranslate> DepartmentsTranslates { get; set; }

        public DbSet<Industry> Industries { get; set; }
        public DbSet<IndustryTranslate> IndustryTranslates { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuTranslate> MenuTranslates { get; set; }
        public DbSet<pages> Pages { get; set; }
        public DbSet<PagesTranslate> PagesTranslates { get; set; }

        public DbSet<News> News { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<NewsCategoryTranslate> NewsCategoryTranslates { get; set; }
        public DbSet<NewsTranslate> NewsTranslates { get; set; }

       
        public DbSet<Partners> Partners { get; set; }
        public DbSet<PartnersData> PartnersDatas { get; set; }
        public DbSet<PartnersDataTranslate> PartnersDataTranslates { get; set; }
        public DbSet<PartnerTranslate> PartnerTranslates { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTranslate> ProjectTranslates { get; set; }

        public DbSet<Representatives> Representatives { get; set; }
        public DbSet<RepresentativesTranslate> RepresentativesTranslates { get; set; }

        public DbSet<Services> Services { get; set; }
        public DbSet<ServiceTranslate> ServiceTranslates { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceTypeTranslate> ServiceTypeTranslates { get; set; }

        public DbSet<TradingHouses> TradingHouses { get; set; }
        public DbSet<TradingHousesTranslate> TradingHousesTranslates { get; set; }

        public DbSet<NewsPaper> NewsPaper { get; set; }
        public DbSet<NewsPaperData> NewsPaperData { get; set; }
        public DbSet<NewsPapersTranslate> NewsPapersTranslates { get; set; }
        public DbSet<NewsPaperFiles> NewsPaperFiles { get; set; }
        public DbSet<Payment> Payments{ get; set; }
        public DbSet<Declaration> Declarations { get; set; }
        public DbSet<DeclarationImage> DeclarationImages { get; set; }
        public DbSet<Tariff> Tariffs{ get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Charity> Charities { get; set; }
        public DbSet<PaymentCharity> PaymentCharity { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<BannerTranslate> BannerTranslates { get; set; }
        public DbSet<Subscribers> Subscribers { get; set; }
        public DbSet<Emails> Emails { get; set; }
        public DbSet<OnlineTrading> OnlineTradings { get; set; }
        public DbSet<OnlineTradingCategory> OnlineTradingCategories { get; set; }
        public DbSet<OnlineTradingActivityType> OnlineTradingActivityTypes { get; set; }
        public DbSet<OnlineTradingTranslate> OnlineTradingTranslates { get; set; }
        public DbSet<OnlineTradingCategoryTranslate> OnlineTradingCategoryTranslates { get; set; }
        public DbSet<OnlineTradingActivityTypeTranslate> OnlineTradingActivityTypeTranslates { get; set; }

        public DbSet<NativeProduction> NativeProductions { get; set; }
        public DbSet<NativeProductionTranslate> NativeProductionTranslates{ get; set; }
        public DbSet<Sayings> Sayings { get; set; }
        public DbSet<SayingsTranslate> SayingsTranslates { get; set; }
        public DbSet<Visitors> Visitors { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }

        public DbSet<Widget> Widgets { get; set; }
        public DbSet<WidgetTranslate> WidgetTranslates { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public DbSet<MembershipRequest> MembershipRequests { get; set; }
        public DbSet<CallBackTranslate> CallBackTranslates { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Применение всех конфигурация в сборке
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
