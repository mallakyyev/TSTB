using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.AdvertisementDTO;
using TSTB.BLL.DTOs.ApplicationUserModelDTO;
using TSTB.BLL.DTOs.BannerModelDTO;
using TSTB.BLL.DTOs.BillingModelDTO;
using TSTB.BLL.DTOs.CallBackModelDTO;
using TSTB.BLL.DTOs.CharityModelDTO;
using TSTB.BLL.DTOs.DepartmentModelDTO;
using TSTB.BLL.DTOs.IndustryModelDTO;
using TSTB.BLL.DTOs.LanguageDTO;
using TSTB.BLL.DTOs.MenuModelDTO;
using TSTB.BLL.DTOs.NativeProductionsDTO;
using TSTB.BLL.DTOs.NewsModelDTO;
using TSTB.BLL.DTOs.NewsPaperModelDTO;
using TSTB.BLL.DTOs.OnlineTradeDTO;
using TSTB.BLL.DTOs.OrganizationModelDTO;
using TSTB.BLL.DTOs.PartnersModelDTO;
using TSTB.BLL.DTOs.ProjectsModelDTO;
using TSTB.BLL.DTOs.RepresentativesModelDTO;
using TSTB.BLL.DTOs.SayingsDTO;
using TSTB.BLL.DTOs.ServicesDTO;
using TSTB.BLL.DTOs.TradingHousesDTO;
using TSTB.BLL.DTOs.VisitorDTO;
using TSTB.BLL.DTOs.WidgetModelDTO;
using TSTB.DAL.Models.Advertisement;
using TSTB.DAL.Models.Banner;
using TSTB.DAL.Models.Billing;
using TSTB.DAL.Models.CallBacks;
using TSTB.DAL.Models.Charity;
using TSTB.DAL.Models.Departments;
using TSTB.DAL.Models.Industry;
using TSTB.DAL.Models.Ip;
using TSTB.DAL.Models.Language;
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
using TSTB.DAL.Models.TradingHouse;
using TSTB.DAL.Models.User;
using TSTB.DAL.Models.Widget;
using TSTB.Web.Areas.Employee.Models;

namespace TSTB.Web.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<CategoryTranslate, CategoryTranslateDTO>();
            //Departments mapping 
            CreateMap<Departments, DepartmentDTO>();
            CreateMap<DepartmentDTO, Departments>();
            CreateMap<Departments, CreateDepartmentDTO>();
            CreateMap<CreateDepartmentDTO, Departments>();
            CreateMap<Departments, EditDepartmentDTO>();
            CreateMap<EditDepartmentDTO, Departments>();

            CreateMap<DepartmentsTranslate, DepartmentTranslateDTO>();
            CreateMap<DepartmentTranslateDTO, DepartmentsTranslate>();

            //Projects mapping 
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();
            CreateMap<Project, CreateProjectDTO>();
            CreateMap<CreateProjectDTO, Project>();
            CreateMap<Project, EditProjectsDTO>();
            CreateMap<EditProjectsDTO, Project>();


            CreateMap<ProjectTranslate, ProjectTranslateDTO>();
            CreateMap<ProjectTranslateDTO, ProjectTranslate>();

            //Menu mapping 
            CreateMap<Menu, MenuDTO>();
            CreateMap<MenuDTO, Menu>();
            CreateMap<Menu, CreateMenuDTO>();
            CreateMap<CreateMenuDTO, Menu>();
            CreateMap<Menu, EditMenuDTO>();
            CreateMap<EditMenuDTO, Menu>();

            CreateMap<Menu, MenuHierarchyDTO>();
            CreateMap<MenuHierarchyDTO, Menu>();

            CreateMap<MenuTranslate, MenuTranslateDTO>();
            CreateMap<MenuTranslateDTO, MenuTranslate>();

            //Pages mapping 
            CreateMap<Pages, PagesDTO>();
            CreateMap<PagesDTO, Pages>();
            CreateMap<Pages, CreatePagesDTO>();
            CreateMap<CreatePagesDTO, Pages>();
            CreateMap<Pages, EditPageDTO>();
            CreateMap<EditPageDTO, Pages>();

            CreateMap<PagesTranslate, PagesTranslateDTO>();
            CreateMap<PagesTranslateDTO, PagesTranslate>();

            //NewsCategory mapping 
            CreateMap<NewsCategory, NewsCategoryDTO>();
            CreateMap<NewsCategoryDTO, NewsCategory>();
            CreateMap<NewsCategory, CreateNewsCategoryDTO>();
            CreateMap<CreateNewsCategoryDTO, NewsCategory>();
            CreateMap<NewsCategory, EditNewsCategoryDTO>();
            CreateMap<EditNewsCategoryDTO, NewsCategory>();

            CreateMap<NewsCategoryTranslate, NewsCategoryTranslateDTO>();
            CreateMap<NewsCategoryTranslateDTO, NewsCategoryTranslate>();

            //News mapping 
            CreateMap<News, NewsDTO>();
            CreateMap<NewsDTO, News>();
            CreateMap<News, CreateNewsDTO>();
            CreateMap<CreateNewsDTO, News>();
            CreateMap<News, EditNewsDTO>();
            CreateMap<EditNewsDTO, News>();

            CreateMap<NewsTranslate, NewsTranslateDTO>();
            CreateMap<NewsTranslateDTO, NewsTranslate>();

            //Service mapping 
            CreateMap<Services, ServiceDTO>();
            CreateMap<ServiceDTO, Services>();
            CreateMap<Services, CreateServiceDTO>();
            CreateMap<CreateServiceDTO, Services>();
            CreateMap<Services, EditServiceDTO>();
            CreateMap<EditServiceDTO, Services>();

            CreateMap<ServiceTranslate, ServiceTranslateDTO>();
            CreateMap<ServiceTranslateDTO, ServiceTranslate>();

            //ServiceType mapping 
            CreateMap<ServiceType, ServiceTypeDTO>();
            CreateMap<ServiceTypeDTO, ServiceType>();
            CreateMap<ServiceType, CreateServiceTypeDTO>();
            CreateMap<CreateServiceTypeDTO, ServiceType>();
            CreateMap<ServiceType, EditServiceTypeDTO>();
            CreateMap<EditServiceTypeDTO, ServiceType>();

            CreateMap<ServiceTypeTranslate, ServiceTypeTranslateDTO>();
            CreateMap<ServiceTypeTranslateDTO, ServiceTypeTranslate>();

            //Industry mapping 
            CreateMap<Industry, IndustryDTO>();
            CreateMap<IndustryDTO, Industry>();
            CreateMap<Industry, CreateIndustryDTO>();
            CreateMap<CreateIndustryDTO, Industry>();
            CreateMap<Industry, EditIndustryDTO>();
            CreateMap<EditIndustryDTO, Industry>();

            CreateMap<IndustryTranslate, IndustryTranslateDTO>();
            CreateMap<IndustryTranslateDTO, IndustryTranslate>();

            //Partners mapping 
            CreateMap<Partners, PartnersDTO>();
            CreateMap<PartnersDTO, Partners>();
            CreateMap<Partners, CreatePartnerDTO>();
            CreateMap<CreatePartnerDTO, Partners>();
            CreateMap<Partners, EditPartnerDTO>();
            CreateMap<EditPartnerDTO, Partners>();

            CreateMap<PartnerTranslate, PartnerTranslateDTO>();
            CreateMap<PartnerTranslateDTO, PartnerTranslate>();

            //PartnerData mapping
            CreateMap<PartnersData, PartnerDataDTO>();
            CreateMap<PartnerDataDTO, PartnersData>();
            CreateMap<PartnersData, CreatePartnerDataDTO>();
            CreateMap<CreatePartnerDataDTO, PartnersData>();
            CreateMap<PartnersData, EditPartnerDataDTO>();
            CreateMap<EditPartnerDataDTO, PartnersData>();

            CreateMap<PartnersDataTranslate, PartnersDataTranslateDTO>();
            CreateMap<PartnersDataTranslateDTO, PartnersDataTranslate>();


            //Cities mapping
            CreateMap<Cities, CitiesDTO>();
            CreateMap<CitiesDTO, Cities>();
            CreateMap<Cities, CreateCityDTO>();
            CreateMap<CreateCityDTO, Cities>();
            CreateMap<Cities, EditCityDTO>();
            CreateMap<EditCityDTO, Cities>();

            CreateMap<CitiesTranslate, CitiesTranslateDTO>();
            CreateMap<CitiesTranslateDTO, CitiesTranslate>();

            //CallBack mapping
            CreateMap<CallBack, CallBackDTO>();
            CreateMap<CallBackDTO, CallBack>();
            CreateMap<CallBack, CreateCallBackDTO>();
            CreateMap<CreateCallBackDTO, CallBack>();
            CreateMap<CallBack, EditCallBackDTO>();
            CreateMap<EditCallBackDTO, CallBack>();

            CreateMap<CallBackTranslate, CallBackTranslateDTO>();
            CreateMap<CallBackTranslateDTO, CallBackTranslate>();

            //Representative mapping
            CreateMap<Representatives, RepresentativeDTO>();
            CreateMap<RepresentativeDTO, Representatives>();
            CreateMap<Representatives, CreateRepresentativeDTO>();
            CreateMap<CreateRepresentativeDTO, Representatives>();
            CreateMap<Representatives, EditRepresentativeDTO>();
            CreateMap<EditRepresentativeDTO, Representatives>();

            CreateMap<RepresentativesTranslate, RepresentativeTranslateDTO>();
            CreateMap<RepresentativeTranslateDTO, RepresentativesTranslate>();

            //Trading Houses mapping
            CreateMap<TradingHouses, TradingHouseDTO>();
            CreateMap<TradingHouseDTO, TradingHouses>();
            CreateMap<TradingHouses, CreateTradingHouseDTO>();
            CreateMap<CreateTradingHouseDTO, TradingHouses>();
            CreateMap<TradingHouses, EditTradingHousesDTO>();
            CreateMap<EditTradingHousesDTO, TradingHouses>();

            CreateMap<TradingHousesTranslate, TradingHouseTranslateDTO>();
            CreateMap<TradingHouseTranslateDTO, TradingHousesTranslate>();

            //NewsPaper Mapping
            //Trading Houses mapping
            CreateMap<NewsPaper, NewsPaperDTO>();
            CreateMap<NewsPaperDTO, NewsPaper>();
            CreateMap<NewsPaper, CreateNewsPaperDTO>();
            CreateMap<CreateNewsPaperDTO, NewsPaper>();
            CreateMap<NewsPaper, EditNewsPaperDTO>();
            CreateMap<EditNewsPaperDTO, NewsPaper>();

            CreateMap<NewsPapersTranslate, NewsPaperTranslateDTO>();
            CreateMap<NewsPaperTranslateDTO, NewsPapersTranslate>();

            //News Paper data mapping
            CreateMap<NewsPaperData, NewsPaperDataDTO>();
            CreateMap<NewsPaperDataDTO, NewsPaperData>();
            CreateMap<NewsPaperData, CreateNewsPaperDataDTO>();
            CreateMap<CreateNewsPaperDataDTO, NewsPaperData>();
            CreateMap<NewsPaperData, EditNewsPaperDataDTO>();
            CreateMap<EditNewsPaperDataDTO, NewsPaperData>();

            //News Paper FIles mapping
            CreateMap<NewsPaperFiles, NewsPaperFileDTO>();
            CreateMap<NewsPaperFileDTO, NewsPaperFiles>();
            CreateMap<NewsPaperFiles, CreateNewsPaperFileDTO>();
            CreateMap<CreateNewsPaperFileDTO, NewsPaperFiles>();
            CreateMap<NewsPaperFiles, EditNewsPaperFileDTO>();
            CreateMap<EditNewsPaperFileDTO, NewsPaperFiles>();

            //User Mapping
            CreateMap<ApplicationUser, ApplicationUserDTO>();
            CreateMap<ApplicationUserDTO, ApplicationUser>();
            CreateMap<ApplicationUser, CreateApplicationUserDTO>();
            CreateMap<CreateApplicationUserDTO, ApplicationUser>();
            CreateMap<ApplicationUser, EditApplicationUserDTO>();
            CreateMap<EditApplicationUserDTO, ApplicationUser>();

            //Ogranization Mapping 
            CreateMap<Organization, OrganizationDTO>();
            CreateMap<OrganizationDTO, Organization>();
            CreateMap<Organization, CreateOrganizationDTO>();
            CreateMap<CreateOrganizationDTO, Organization>();
            CreateMap<Organization, EditOrganizationDTO>();
            CreateMap<EditOrganizationDTO, Organization>();

            //Declaration Mapping 
            CreateMap<Declaration, DeclarationDTO>();
            CreateMap<DeclarationDTO, Declaration>();
            CreateMap<Declaration, CreateDeclarationDTO>();
            CreateMap<CreateDeclarationDTO, Declaration>();
            CreateMap<Declaration, EditDeclarationDTO>();
            CreateMap<EditDeclarationDTO, Declaration>();

            CreateMap<EditDeclatarionAccountant, EditDeclarationDTO>();
            CreateMap<EditDeclarationDTO, EditDeclatarionAccountant>();
            CreateMap<Declaration, EditDeclatarionAccountant>();
            CreateMap<EditDeclatarionAccountant, Declaration>();
            CreateMap<EditDeclatarionAccountant, DeclarationDTO>();
            CreateMap<DeclarationDTO, EditDeclatarionAccountant>();

            CreateMap<DeclarationAccount, EditDeclarationDTO>();
            CreateMap<EditDeclarationDTO, DeclarationAccount>();
            CreateMap<Declaration, DeclarationAccount>();
            CreateMap<DeclarationAccount, Declaration>();
            CreateMap<DeclarationAccount, DeclarationDTO>();
            CreateMap<DeclarationDTO, DeclarationAccount>();
            CreateMap<DeclarationAccount, EditDeclatarionAccountant>();
            CreateMap<EditDeclatarionAccountant, DeclarationAccount>();

            // Payment Mapping
            CreateMap<Payment, PaymentDTO>();
            CreateMap<PaymentDTO, Payment>();
            CreateMap<Payment, CreatePaymentDTO>();
            CreateMap<CreatePaymentDTO, Payment>();
            CreateMap<Payment, EditPaymentDTO>();
            CreateMap<EditPaymentDTO, Payment>();

            //Charity Mapping
            CreateMap<Charity, CharityDTO>();
            CreateMap<CharityDTO, Charity>();
            CreateMap<Charity, CreateCharityDTO>();
            CreateMap<CreateCharityDTO, Charity>();
            CreateMap<Charity, EditCharityDTO>();
            CreateMap<EditCharityDTO, Charity>();

            //Payment charity
            CreateMap<PaymentCharity, EditPaymentCharityDTO>();
            CreateMap<EditPaymentCharityDTO, PaymentCharity>();
            CreateMap<PaymentCharity, CreatePaymentCharityDTO>();
            CreateMap<CreatePaymentCharityDTO, PaymentCharity>();
            CreateMap<PaymentCharity, EditPaymentCharityDTO>();
            CreateMap<EditPaymentCharityDTO, PaymentCharity>();


            CreateMap<Charity, CharityPaymentModel>();
            CreateMap<CharityPaymentModel, Charity>();
            CreateMap<CharityPaymentModel, CharityDTO>();
            CreateMap<CharityDTO, CharityPaymentModel>();


            //Banners mapping
            CreateMap<Banner, BannerDTO>();
            CreateMap<BannerDTO, Banner>();
            CreateMap<Banner, CreateBannerDTO>();
            CreateMap<CreateBannerDTO, Banner>();
            CreateMap<Banner, EditBannerDTO>();
            CreateMap<EditBannerDTO, Banner>();

            CreateMap<BannerTranslate, BannerTranslateDTO>();
            CreateMap<BannerTranslateDTO, BannerTranslate>();

            //Online Trading
            // Online Trading
            CreateMap<OnlineTrading, OnlineTradingDTO>();
            CreateMap<OnlineTradingDTO, OnlineTrading>();
            CreateMap<OnlineTrading, CreateOnlineTradingDTO>();
            CreateMap<CreateOnlineTradingDTO, OnlineTrading>();
            CreateMap<OnlineTrading, EditOnlineTradingDTO>();
            CreateMap<EditOnlineTradingDTO, OnlineTrading>();

            CreateMap<OnlineTradingTranslate, OnlineTradingTranslateDTO>();
            CreateMap<OnlineTradingTranslateDTO, OnlineTradingTranslate>();

            // Online Trading Category
            CreateMap<OnlineTradingCategory, OnlineTradingCategoryDTO>();
            CreateMap<OnlineTradingCategoryDTO, OnlineTradingCategory>();
            CreateMap<OnlineTradingCategory, CreateOnlineTradingCategoryDTO>();
            CreateMap<CreateOnlineTradingCategoryDTO, OnlineTradingCategory>();
            CreateMap<OnlineTradingCategory, EditOnlineTradingCategoryDTO>();
            CreateMap<EditOnlineTradingCategoryDTO, OnlineTradingCategory>();

            CreateMap<OnlineTradingCategoryTranslate, OnlineTradingCategoryTranslateDTO>();
            CreateMap<OnlineTradingCategoryTranslateDTO, OnlineTradingCategoryTranslate>();

            //Online Trading Activity Type
            CreateMap<OnlineTradingActivityType, OnlineTradingActivityTypeDTO>();
            CreateMap<OnlineTradingActivityTypeDTO, OnlineTradingActivityType>();
            CreateMap<OnlineTradingActivityType, CreateOnlineTradingActivityTypeDTO>();
            CreateMap<CreateOnlineTradingActivityTypeDTO, OnlineTradingActivityType>();
            CreateMap<OnlineTradingActivityType, EditOnlineTradingActivityTypeDTO>();
            CreateMap<EditOnlineTradingActivityTypeDTO, OnlineTradingActivityType>();

            CreateMap<OnlineTradingActivityTypeTranslate, OnlineTradingActivityTypeTranslateDTO>();
            CreateMap<OnlineTradingActivityTypeTranslateDTO, OnlineTradingActivityTypeTranslate>();

            // Native Production 
            CreateMap<NativeProduction, NativeProdutionDTO>();
            CreateMap<NativeProdutionDTO, NativeProduction>();
            CreateMap<NativeProduction, CreateNativeProductionDTO>();
            CreateMap<CreateNativeProductionDTO, NativeProduction>();
            CreateMap<NativeProduction, EditNativeProductionDTO>();
            CreateMap<EditNativeProductionDTO, NativeProduction>();

            CreateMap<NativeProductionTranslate, NativeProductionTranslateDTO>();
            CreateMap<NativeProductionTranslateDTO, NativeProductionTranslate>();


            // Saying Mapping 

            CreateMap<Sayings, SayingsDTO>();
            CreateMap<SayingsDTO, Sayings>();
            CreateMap<Sayings, CreateSayingsDTO>();
            CreateMap<CreateSayingsDTO, Sayings>();
            CreateMap<Sayings, EditSayingsDTO>();
            CreateMap<EditSayingsDTO, Sayings>();

            CreateMap<SayingsTranslate, SayingsTranslateDTO>();
            CreateMap<SayingsTranslateDTO, SayingsTranslate>();

            //Visitors 
            CreateMap<Visitors, CreateVisitorDTO>();
            CreateMap<CreateVisitorDTO, Visitors>();

            //Advertisement
            CreateMap<Advertisement, AdvertisementDTO>();
            CreateMap<AdvertisementDTO, Advertisement>();
            CreateMap<Advertisement, CreateAdvertisementDTO>();
            CreateMap<CreateAdvertisementDTO, Advertisement>();
            CreateMap<Advertisement, EditAdvertisementDTO>();
            CreateMap<EditAdvertisementDTO, Advertisement>();


            //Widget Mapping
            CreateMap<Widget, WidgetDTO>();
            CreateMap<WidgetDTO, Widget>();
            CreateMap<Widget, CreateWidgetDTO>();
            CreateMap<CreateWidgetDTO, Widget>();
            CreateMap<Widget, EditWidgetDTo>();
            CreateMap<EditWidgetDTo, Widget>();

            CreateMap<WidgetTranslate, WidgetTranslateDTO>();
            CreateMap<WidgetTranslateDTO, WidgetTranslate>();

            //Language mapping 
            CreateMap<Language, LanguageDTO>();
            CreateMap<LanguageDTO, Language>();


        }
    }
}
