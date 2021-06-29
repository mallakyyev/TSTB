using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSTB.Web.Areas.Admin.Utilities
{
    public class API
    {
        public static string GetAllDepartments { get; } = "/api/DepartmentsAPI";
        public static string GetAllCallBacks { get; } = "/api/CallBacksAPI";
        public static string GetAllIndustry { get; } = "/api/IndustryAPI";
        public static string GetAllMenu { get; } = "/api/MenuAPI";
        public static string GetAllNews { get; } = "/api/NewsAPI";
        public static string GetAllNewsCategory { get; } = "/api/NewsAPI/GetAllNewsCategories";
        public static string GetAllPages { get; } = "/api/PagesAPI";
        public static string GetAllPartners { get; } = "/api/PartnerAPI";
        public static string GetAllProjects { get; } = "/api/ProjectAPI";
        public static string GetAllRepresentative { get; } = "/api/RepresentativeAPI";
        public static string GetAllServices { get; } = "/api/ServicesAPI";
        public static string GetAllTradingHouses { get; } = "/api/TradingHouseAPI";
        public static string GetAllMenuWithOutPage { get; } = "api/MenuAPI/GetMenuWithOutPage";
        public static string GetAllServiceTypes { get; } = "/api/ServicesAPI/ServiceTypes";
        public static string GetAllCities { get; } = "/api/CallBacksAPI/GetAllCities";
        public static string GetAllNewsPapers { get; } = "/api/NewsPaperAPI";
        public static string GetAllNewsPaperData { get; } = "/api/NewsPaperAPI/Data";
        public static string GetAllUsers { get; } = "/api/ApplicationUserAPI";
        public static string GetAllBanners { get; } = "/api/BannerAPI";
        public static string GetAllOnlineTrading { get; } = "/api/OnlineTradingAPI";
        public static string GetAllOnlineTradingActivities { get; } = "/api/OnlineTradingAPI/Activity"; 
        public static string GetAllOnlineTradingCategories { get; } = "/api/OnlineTradingAPI/Categories";
        public static string GetAllNativeProductions { get; } = "/api/NativeProductionAPI";
        public static string GetAllSayings { get; } = "/api/SayingsAPI";
        public static string GetAllAdvertisements { get; } = "/api/AdvertisementAPI"; 
        public static string GetAllWidgets { get; } = "/api/WidgetAPI";
        public static string GetAllMembershipRequests { get; } = "/api/MembershipAPI";

    }
}
