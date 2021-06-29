using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MaxMind.GeoIP2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TSTB.BLL.DTOs.EmailsModelDTO;
using TSTB.BLL.DTOs.MenuModelDTO;
using TSTB.BLL.DTOs.VisitorDTO;
using TSTB.BLL.Services.AdvertisementService;
using TSTB.BLL.Services.Banner;
using TSTB.BLL.Services.CallBacks;
using TSTB.BLL.Services.CurrencyRateService;
using TSTB.BLL.Services.Email;
using TSTB.BLL.Services.Industry;
using TSTB.BLL.Services.Menu;
using TSTB.BLL.Services.NativeProductionService;
using TSTB.BLL.Services.News;
using TSTB.BLL.Services.Sayings;
using TSTB.BLL.Services.Services;
using TSTB.BLL.Services.Settings;
using TSTB.BLL.Services.Subscribe;
using TSTB.BLL.Services.VisitorsService;
using TSTB.BLL.Services.WidgetService;
using TSTB.DAL.Models.Email;
using TSTB.DAL.Models.Ip;
using TSTB.DAL.Models.Settings;
using TSTB.Web.Models;
using Hangfire;
using TSTB.DAL.Models.CurrencyRate;
using Microsoft.Extensions.Localization;

namespace TSTB.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISubscribeService _subscriberService;
        private readonly ISettingsService _settings;
        private readonly IEmailService _emailService;
        private readonly INewsService _newsService;
        private readonly IBannerService _bannerService;
        private readonly INativeProductionService _nativeProductionService;
        private readonly IServiceService _serviceService;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IVisitorsService _visitorService;
        private readonly ICallBackService _callBackService;
        private readonly ISayingsService _sayingsService;
        private readonly IIndustryService _industryService;
        private readonly IAdvertisementService _advertisementService;
        private readonly IWidgetService _widgetService;
        private readonly ICuurencyRateService _currencyRateService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        struct Ip
        {
            public int Ip1;
            public int Ip2;
            public int Ip3;
            public int Ip4;
        }
        struct IpRange
        {
            public Ip StartIp;
            public Ip EndIp;
        }
        public HomeController(ILogger<HomeController> logger, ISubscribeService subscribeService, ISettingsService settings,
            IEmailService emailService, INewsService newsService, IBannerService bannerService, INativeProductionService nativeProductionService,
            IServiceService serviceService, IWebHostEnvironment appEnvironment, IVisitorsService visitorService, ICallBackService callBackService,
            ISayingsService sayingsService, IIndustryService industryService, IAdvertisementService advertisementService, IWidgetService widgetService,
            ICuurencyRateService cuurencyRateService, IStringLocalizer<SharedResource> localizer)
        {
            _logger = logger;
            _subscriberService = subscribeService;
            _settings = settings;
            _emailService = emailService;
            _newsService = newsService;
            _bannerService = bannerService;
            _nativeProductionService = nativeProductionService;
            _serviceService = serviceService;
            _appEnvironment = appEnvironment;
            _visitorService = visitorService;
            _callBackService = callBackService;
            _sayingsService = sayingsService;
            _industryService = industryService;
            _advertisementService = advertisementService;
            _widgetService = widgetService;
            _currencyRateService = cuurencyRateService;
            _localizer = localizer;
        }

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
           
            //  Ip of the visitors service
            VisitorCount();
            
            SearchModel s = new SearchModel();
            ViewBag.Saying = _sayingsService.GetAllPublishSayingsAsync();
            ViewBag.FourLastNews = _newsService.GetFourPublishNews();
            ViewBag.Widgets = _widgetService.GetAllPublishWidgets().OrderByDescending(o => o.Id).Take(3);
            ViewBag.SevenNativeProduct = _nativeProductionService.GetSevenPublishNativeProduct();
            ViewBag.Services = _serviceService.GetAllPublishServices();
            ViewBag.Industies = _industryService.GetAllPublishIndustry();
            var adverts = _advertisementService.GetAllPublishAdvertisements();
            ViewBag.LeftAdverts = adverts.Where(p => p.Position == DAL.Models.Enums.BannerPosition.Left);
            ViewBag.RightAdverts = adverts.Where(p => p.Position == DAL.Models.Enums.BannerPosition.Right);
            ViewBag.Achivements = _visitorService.GetAchivements();
            return View(s);
        }

        public IActionResult Contact()
        {
            var result = _callBackService.GetAllPublishcallBacks();

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult Unsubscribe()
        {
            return View();
        }



        public async Task<IActionResult> Unsubscribed(string email)
        {
            List<Settings> settings = new List<Settings>(_settings.GetAllSettings());

            string UnsubLink = settings.Find(x => x.Name == "UnsubLink").Value;
            string AdminEmail = settings.Find(x => x.Name == "AdminEmail").Value;
            string AdminEmailPassword = settings.Find(x => x.Name == "AdminEmailPassword").Value;
            string id = _subscriberService.GetEmail(email);
            if (id.Length > 0)
            {
                SingleEmailDTO sEmail = new SingleEmailDTO();
                sEmail.Header = _localizer["TSTB Unsubscribe"];
                sEmail.Message = _localizer["Please Follow the link below to unsubscribe from TSTB : "] + UnsubLink + "?id=" + id;
                sEmail.Password = AdminEmailPassword;
                sEmail.AdminEmail = AdminEmail;
                sEmail.EmailTo = email;
                sEmail.Subject = _localizer["Unsubscribe Link from TSTB Web Site"];
                bool isSend = await _emailService.SendSingleEmail(sEmail);
                if (isSend)
                    ViewBag.Email = _localizer["Dateiled instructions was send to "] + email + _localizer[" email to unsubscribed."];
                else
                    ViewBag.Email = _localizer["Some thing went wrong, Please try again later !"];
            }
            else
            {
                ViewBag.Email = email + _localizer[" email does not subscribed"];
            }
            return View();
            //return View(email + "does not subscribes");
        }
        public IActionResult UnsubLink(string id)
        {
            _subscriberService.DeleteSubscriber(id);
            ViewBag.UnSub = _localizer["You have succeffully unsubscribed"];
            return View();
        }

        public async Task<ActionResult> Subscribe(string email)
        {
            Subscribers sub = new Subscribers();
            sub.Email = email;
            sub.Id = Guid.NewGuid().ToString();
            bool isSub = await _subscriberService.AddSubscriber(sub);
            if (isSub)
                ViewBag.Sub = email +" "+ _localizer["Email successfully subscribed"];
            else
                ViewBag.Sub = email + " " + _localizer["Email is already subscribed ! "];
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

       
        public void VisitorCount()
        {
            try
            {
                string remoteIpAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

                if (Request.Headers.ContainsKey("X-Forwarded-For"))
                {
                    remoteIpAddress = Request.Headers["X-Forwarded-For"];
                }


                using (var reader = new DatabaseReader(_appEnvironment.WebRootPath + "/Files/GeoLite2-City.mmdb"))
                {
                    // Determine the IP Address of the request
                    var ipAddress = remoteIpAddress;

                    // Get the city from the IP Address
                    var city = reader.City(ipAddress);

                    string[] lines = System.IO.File.ReadAllLines(_appEnvironment.WebRootPath + "/Files/TurkmenistanIp.txt");

                    List<IpRange> turkmenIp = new List<IpRange>();
                    foreach (string line in lines)
                    {
                        // Use a tab to indent each line of the file.
                        string[] val = line.Split("-");

                        string[] ipStart = val[0].Split(".");
                        string[] ipEnd = val[1].Split(".");

                        IpRange temp = new IpRange();
                        temp.StartIp.Ip1 = int.Parse(ipStart[0]);
                        temp.StartIp.Ip2 = int.Parse(ipStart[1]);
                        temp.StartIp.Ip3 = int.Parse(ipStart[2]);
                        temp.StartIp.Ip4 = int.Parse(ipStart[3]);

                        temp.EndIp.Ip1 = int.Parse(ipEnd[0]);
                        temp.EndIp.Ip2 = int.Parse(ipEnd[1]);
                        temp.EndIp.Ip3 = int.Parse(ipEnd[2]);
                        temp.EndIp.Ip4 = int.Parse(ipEnd[3]);

                        turkmenIp.Add(temp);
                    }

                    Ip currentIp = new Ip();
                    string[] curIp = ipAddress.Split(".");
                    currentIp.Ip1 = int.Parse(curIp[0]);
                    currentIp.Ip2 = int.Parse(curIp[1]);
                    currentIp.Ip3 = int.Parse(curIp[2]);
                    currentIp.Ip4 = int.Parse(curIp[3]);
                    bool isTmIp = false;
                    foreach (IpRange tmIp in turkmenIp)
                    {
                        if (currentIp.Ip1 >= tmIp.StartIp.Ip1 && currentIp.Ip1 <= tmIp.EndIp.Ip1 &&
                            currentIp.Ip2 >= tmIp.StartIp.Ip2 && currentIp.Ip2 <= tmIp.EndIp.Ip2 &&
                            currentIp.Ip3 >= tmIp.StartIp.Ip3 && currentIp.Ip3 <= tmIp.EndIp.Ip3 &&
                            currentIp.Ip4 >= tmIp.StartIp.Ip4 && currentIp.Ip4 <= tmIp.EndIp.Ip4)
                        {
                            isTmIp = true;
                        }
                    }
                    CreateVisitorDTO v = new CreateVisitorDTO();
                    if (isTmIp)
                        v.Country = "Turkmenistan";
                    else
                        v.Country = city.Country.Name;
                    v.Ip = ipAddress;
                    v.VisitDate = DateTime.Today;
                    _visitorService.AddVisitor(v);
                };
            }catch(Exception e)
            {
                
            }
        }
    }
}
