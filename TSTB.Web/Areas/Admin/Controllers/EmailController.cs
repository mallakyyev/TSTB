using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.EmailsModelDTO;
using TSTB.BLL.Services.Email;
using TSTB.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using TSTB.Web.Data;
using TSTB.BLL.Services.Settings;
using TSTB.DAL.Models.Settings;

namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly ISettingsService _settings;
        static private bool isSend;
        public EmailController(IEmailService emailService, ISettingsService settings)
        {
            _emailService = emailService;
            _settings = settings;
        }
        public IActionResult Index()
        {           
            return View();
        }

        public async Task<IActionResult> SendEmail(EmailsDTO emailModel)
        {
            List<Settings> settings = new List<Settings>(_settings.GetAllSettings());
            emailModel.AdminEmail = settings.Find(x => x.Name == "AdminEmail").Value;
            emailModel.Password = settings.Find(x => x.Name == "AdminEmailPassword").Value;
            emailModel.Message += "\n\n\t Follow the link to Unsubscribe : " + settings.Find(x => x.Name == "UnsubscribeLink").Value;
             isSend = await _emailService.SendEmail(emailModel);
                return RedirectToAction("ErrorView");
        }

        public ActionResult ErrorView()
        {
            return View(isSend);
        }
    }
}