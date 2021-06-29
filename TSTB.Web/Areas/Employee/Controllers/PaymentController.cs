using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TSTB.BLL.DTOs.BillingModelDTO;
using TSTB.BLL.Services.Employee;
using TSTB.BLL.Services.Settings;
using TSTB.DAL.Models.Settings;
using TSTB.DAL.Models.User;
using TSTB.Web.Areas.Admin.Models;
using TSTB.Web.Models;

namespace TSTB.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class PaymentController : Controller
    {
        private readonly IEmployeeService _empService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISettingsService _settingsService;
        public PaymentController(IEmployeeService employeeService, UserManager<ApplicationUser> userManager, ISettingsService settingsService)
        {
            _empService = employeeService;
            _userManager = userManager;
            _settingsService = settingsService;
        }
        // GET: Admin/Payment
        public IActionResult Index()
        {
            return View();
        }


        // GET: Employee/Payment/Create
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        // Post: Employee/Payment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDeclarationDTO CreateDecDTO)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                List<string> err = new List<string>
                {
                    "User does not exists or session timed out!!!"
                };
                ViewBag.ErrorList = err;
                return View(CreateDecDTO);
            }
            string id = user.Id;

            if (ModelState.IsValid)
            {
                await _empService.CreateDeclaration(CreateDecDTO, id);
                return RedirectToAction("Index");
            }

            return View(CreateDecDTO);
        }

        [HttpGet]
        // GET: Employee/Payment/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dec = await _empService.GetDeclarationForEditById(id);
            if (dec == null)
            {
                return NotFound();
            }
            return View(dec);
        }

        // Post: Employee/Payment/Edit/
        [HttpPost]
        public async Task<IActionResult> Edit(EditDeclarationDTO ed)
        {
            if (ModelState.IsValid)
            {
                await _empService.EditDeclaration(ed);
                return RedirectToAction("Index");
            }


            return View(ed);
        }

        // GET: Employee/Payment/Delete/5
        public IActionResult Delete(int? id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Pay(int id)
        {
            return View(id);
        }

        public async Task<IActionResult> TranzitAsync(int id)
        {
            var payment = await _empService.GetPaymentById(id);
            if (payment.StatusPayment != DAL.Models.Enums.StatusPayment.CompleteAuthorizationOrderAmount )
            {
                payment.OrderNumber = Guid.NewGuid().ToString().Replace("-","z").Substring(0,11);
                await _empService.EditPayment(payment);
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using HttpClient client = new HttpClient(clientHandler);
                List<Settings> settings = new List<Settings>(_settingsService.GetAllSettings());

                ////Dictionary<string, object> rootDict = new Dictionary<string, object>();
                ////rootDict.Add("userName", settings.Find(x => x.Name == "userName").Value);
                ////rootDict.Add("password", settings.Find(x => x.Name == "password").Value);
                ////rootDict.Add("orderNumber", payment.OrderNumber);
                ////rootDict.Add("amount", Convert.ToInt64(payment.Amount*100));
                ////rootDict.Add("currency", Int32.Parse(settings.Find(x => x.Name == "currency").Value));

                ////rootDict.Add("returnUrl", settings.Find(x => x.Name == "returnUrl").Value);


                //rootDict.Add("language", settings.Find(x => x.Name == "language").Value);
                //rootDict.Add("pageView", settings.Find(x => x.Name == "pageView").Value);
                //rootDict.Add("failUrl", settings.Find(x => x.Name == "failUrl").Value);
                //rootDict.Add("description", payment.Description);
                ////var requestStr = JsonConvert.SerializeObject(rootDict);
                ////StringContent content = new StringContent(requestStr, Encoding.UTF8, "application/json");

                var url = $"{settings.Find(x => x.Name == "bankUrl").Value}?userName={settings.Find(x => x.Name == "userName").Value}&password={settings.Find(x => x.Name == "password").Value}&orderNumber={payment.OrderNumber}&amount={Convert.ToInt64(payment.Amount * 100)}&currency={Int32.Parse(settings.Find(x => x.Name == "currency").Value)}&returnUrl={settings.Find(x => x.Name == "returnUrl").Value}";
                var result = await client.GetAsync(url);
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
            else
            {
                return RedirectToAction("Index");
            }
                  
        }

        public async Task<IActionResult> SuccessView(string orderId)
        {
            using HttpClient client = new HttpClient();
            Dictionary<string, object> rootDict = new Dictionary<string, object>();
            List<Settings> settings = new List<Settings>(_settingsService.GetAllSettings());
            //rootDict.Add("orderId", orderId);
            //rootDict.Add("password", settings.Find(x => x.Name == "password").Value);
            //rootDict.Add("userName", settings.Find(x => x.Name == "userName").Value);

            //var requestStr = JsonConvert.SerializeObject(rootDict);
            //StringContent content = new StringContent(requestStr, Encoding.UTF8, "application/json");

            //var result = await client.PostAsync(settings.Find(x => x.Name == "bankUrlCheck").Value, content);
            //var response = await result.Content.ReadAsStringAsync();
            //SuccessOrder order = JsonConvert.DeserializeObject<SuccessOrder>(response);
            var url = $"{settings.Find(x => x.Name == "bankUrlCheck").Value}?orderId={orderId}&userName={settings.Find(x => x.Name == "userName").Value}&password={settings.Find(x => x.Name == "password").Value}";
            var result = await client.GetAsync(url);
            var response = await result.Content.ReadAsStringAsync();
            SuccessOrder order = JsonConvert.DeserializeObject<SuccessOrder>(response);
            if (PaidSuccessFully(order))
            {
                var payment = await _empService.GetPaymentByOrderNumber(order.orderNumber);
                payment.BankOrderId = orderId;
                payment.StatusPayment = (TSTB.DAL.Models.Enums.StatusPayment)order.orderStatus;
                await _empService.EditPayment(payment);
                return View(order);
            }
            else
            {
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

        public  ActionResult ErrorView(TSTB.Web.Areas.Employee.Models.ErrorViewModel temp)
        {
            return View(temp);
        }
        public ActionResult FailView(string orderId)
        {
            return View(orderId);
        }
    }
}