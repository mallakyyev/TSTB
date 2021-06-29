using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TSTB.BLL.DTOs.CharityModelDTO;
using TSTB.BLL.Services.Charity;
using TSTB.BLL.Services.Settings;
using TSTB.DAL.Models.Charity;
using TSTB.DAL.Models.Settings;
using TSTB.DAL.Models.User;
using TSTB.Web.Areas.Employee.Models;
using TSTB.Web.Models;

namespace TSTB.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class CharityController : Controller
    {
        private readonly ICharityService _charityService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IPaymentCharityService _paymentCharityService;
        private readonly ISettingsService _settingsService;
        public CharityController(ICharityService charityService, UserManager<ApplicationUser> userManager, IMapper mapper, 
                                    IPaymentCharityService paymentCharityService,
                                    ISettingsService settingsService)
        {
            _charityService = charityService;
            _userManager = userManager;
            _mapper = mapper;
            _paymentCharityService = paymentCharityService;
            _settingsService = settingsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        // GET: Employee/Charity/Edit/5
        public async Task<IActionResult> Edit(int id)
        { 
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                return BadRequest("User does not exists");
            }
            var ch = await _charityService.GetCharityById(id);
            CharityPaymentModel cPm = _mapper.Map<CharityPaymentModel>(ch);
            cPm.CharityId = ch.Id;
            cPm.ApplicationUserId = user.Id;

            return View(cPm);
        }
        public async Task<IActionResult> Create(CharityPaymentModel model)
        {
            CreatePaymentCharityDTO ch = new CreatePaymentCharityDTO
            {
                Amount = model.Amount * 100,
                ApplicationtUserId = model.ApplicationUserId,
                CharityId = model.CharityId,
                Description = model.PaymentDescription,
                PaymentDate = DateTime.Now,
                PaymentStatus = DAL.Models.Enums.StatusPayment.NotPaid,
                PaymentNumber = Guid.NewGuid().ToString()
            };
            int id = await _paymentCharityService.CreatePaymentCharity(ch);

            using HttpClient client = new HttpClient();
            List<Settings> settings = new List<Settings>(_settingsService.GetAllSettings());
           
            Dictionary<string, object> rootDict = new Dictionary<string, object>();
            rootDict.Add("amount", Convert.ToInt64(ch.Amount));
            rootDict.Add("orderNumber", ch.PaymentNumber);
            rootDict.Add("password", settings.Find(x => x.Name == "password").Value);
            rootDict.Add("returnUrl", settings.Find(x => x.Name == "returnUrlCharity").Value);
            rootDict.Add("userName", settings.Find(x => x.Name == "userName").Value);
            rootDict.Add("currency", Int32.Parse(settings.Find(x => x.Name == "currency").Value));
            rootDict.Add("language", settings.Find(x => x.Name == "language").Value);
            rootDict.Add("pageView", settings.Find(x => x.Name == "pageView").Value);
            rootDict.Add("failUrl", settings.Find(x => x.Name == "failUrlCharity").Value+"?id="+id);
            rootDict.Add("description", ch.Description);
            var requestStr = JsonConvert.SerializeObject(rootDict);
            StringContent content = new StringContent(requestStr, Encoding.UTF8, "application/json");

            var result = await client.PostAsync(settings.Find(x => x.Name == "bankUrl").Value, content);
            var response = await result.Content.ReadAsStringAsync();
            ResponseRegistrationOrder deserialize = JsonConvert.DeserializeObject<ResponseRegistrationOrder>(response);

            if (deserialize.errorCode == 0)
            {
                return Redirect(deserialize.formUrl);
            }
            else
            {
                TSTB.Web.Areas.Employee.Models.ErrorViewModel temp = new TSTB.Web.Areas.Employee.Models.ErrorViewModel()
                {
                    ErrorMessage = deserialize.errorMessage
                };
                return RedirectToAction(actionName: "ErrorView", routeValues: temp);
            }
        }

        public async Task<IActionResult> SuccessView(string orderId)
        {
            using HttpClient client = new HttpClient();
            Dictionary<string, object> rootDict = new Dictionary<string, object>();
            List<Settings> settings = new List<Settings>(_settingsService.GetAllSettings());
            rootDict.Add("orderId", orderId);
            rootDict.Add("password", settings.Find(x => x.Name == "password").Value);
            rootDict.Add("userName", settings.Find(x => x.Name == "userName").Value);

            var requestStr = JsonConvert.SerializeObject(rootDict);
            StringContent content = new StringContent(requestStr, Encoding.UTF8, "application/json");

            var result = await client.PostAsync(settings.Find(x => x.Name == "bankUrlCheck").Value, content);
            var response = await result.Content.ReadAsStringAsync();
            SuccessOrder order = JsonConvert.DeserializeObject<SuccessOrder>(response);

            if (PaidSuccessFully(order))
            {
                 await _paymentCharityService.GetPaymentByPaymentNumberforEdit(order.orderNumber, orderId,(TSTB.DAL.Models.Enums.StatusPayment)order.orderStatus);
               
                return View(order);
            }
            else
            {
                await _paymentCharityService.DeleteByPaymentNumber(order.orderNumber);
                TSTB.Web.Areas.Employee.Models.ErrorViewModel temp = new TSTB.Web.Areas.Employee.Models.ErrorViewModel()
                {
                    ErrorMessage = order.errorMessage
                };
                return RedirectToAction(actionName: "ErrorView", routeValues: temp);
            }
        }

        private static bool PaidSuccessFully(SuccessOrder order)
        {
            return order.errorCode == 0 && order.orderStatus == 2;
        }

        public ActionResult ErrorView(TSTB.Web.Areas.Employee.Models.ErrorViewModel temp)
        {
            return View(temp);
        }
        public async Task<ActionResult> FailView(int id)
        {
            await _paymentCharityService.RemovePaymentCharity(id);
            return View();
        }

    }
}