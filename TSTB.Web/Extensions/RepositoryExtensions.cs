using Microsoft.CodeAnalysis.Host;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSTB.BLL.Services.ApplicationUser;
using TSTB.BLL.Services.Banner;
using TSTB.BLL.Services.CallBacks;
using TSTB.BLL.Services.Charity;
using TSTB.BLL.Services.Departments;
using TSTB.BLL.Services.Employee;
using TSTB.BLL.Services.ImageService;
using TSTB.BLL.Services.Industry;
using TSTB.BLL.Services.Language;
using TSTB.BLL.Services.Menu;
using TSTB.BLL.Services.News;
using TSTB.BLL.Services.NewsCategory;
using TSTB.BLL.Services.NewsPaper;
using TSTB.BLL.Services.Pages;
using TSTB.BLL.Services.Partner;
using TSTB.BLL.Services.Projects;
using TSTB.BLL.Services.Representative;
using TSTB.BLL.Services.SearchService;
using TSTB.BLL.Services.Services;
using TSTB.BLL.Services.Settings;
using TSTB.BLL.Services.Tariff;
using TSTB.BLL.Services.TradingHouses;
using TSTB.BLL.Services.Email;
using TSTB.BLL.Services.Subscribe;
using TSTB.BLL.Services.OnlineTrading;
using TSTB.BLL.Services.NativeProductionService;
using TSTB.BLL.Services.Sayings;
using TSTB.BLL.Services.VisitorsService;
using TSTB.BLL.Services.AdvertisementService;
using TSTB.BLL.Services.WidgetService;
using TSTB.BLL.Services.CurrencyRateService;
using TSTB.BLL.Services.MembershipRequest;

namespace TSTB.Web.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //services.AddTransient<IEmailSender, EmailService>();
            services.AddTransient<IDepartmentsService, DepartmentService>();
            services.AddTransient<BLL.Services.Language.ILanguageService, LanguageService>();
            services.AddTransient<IProjectsService, ProjectService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IPagesService, PagesService>();
            services.AddTransient<INewsCategoryService, NewsCategoryService>();
            services.AddTransient<INewsService, NewsService>(); 
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<IServicesTypeService, ServiceTypeService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IWidgetService, WidgetService>();
            services.AddTransient<IPartnerService, PartnerService>();
            services.AddTransient<IPartnerDataService, PartnerDataService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ICallBackService, CallBackService>();
            services.AddTransient<IRepresentativeService, RepresentativeService>();
            services.AddTransient<ITradingHouseService, TradingHousesService>();
            services.AddTransient<INewsPaperService, NewsPaperService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ITariffService, TariffService>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<ICharityService, CharityService>();
            services.AddTransient<IPaymentCharityService, PaymentCharityService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<IBannerService, BannerService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ISubscribeService, SubscribeService>();
            services.AddTransient<IOnlineTradingService, OnlineTradingService>();
            services.AddTransient<INativeProductionService, NativeProductionService>();
            services.AddTransient<ISayingsService, SayingsService>();
            services.AddTransient<IVisitorsService, VisitorsService>();
            services.AddTransient<IAdvertisementService, AdvertisementService>();
            services.AddTransient<IWidgetService, WidgetService>();
            services.AddTransient<IIndustryService, IndustryService>();
            services.AddScoped<ICuurencyRateService, CurrencyRateService>();
            services.AddTransient<IMembershipRequestService, MembershipRequestService>();
            //Add Scoped Services


            return services;
        }
    }
}
