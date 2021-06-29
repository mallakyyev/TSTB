using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSTB.BLL.Services.CallBacks;
using TSTB.BLL.Services.Settings;
using TSTB.DAL.Models.Settings;

namespace TSTB.Web.Components
{
    public class FooterSettingsViewComponent : ViewComponent
    {
        private readonly ISettingsService _settingsService;
        private readonly ICallBackService _callBackService;

        public FooterSettingsViewComponent(ISettingsService settingsService, ICallBackService callBackService)
        {
            _settingsService = settingsService;
            _callBackService = callBackService;
        }

        public IViewComponentResult Invoke()
        {
            string[] settingsString = new string[] { "PhoneSPPT", "AddressSPPT", "EmailSPPT" };

            List<Settings> settings = new List<Settings>();

            var getSettings = _settingsService.GetAllSettings();
            var callBack = _callBackService.GetAllCallBacks().SingleOrDefault(s => s.City == "Ашхабад" || s.City == "Ashgabat" || s.City == "Aşgabat");

            foreach (var name in settingsString)
            {
                if (name == "AddressSPPT" && callBack != null)
                {
                    settings.Add(new Settings()
                    {
                        Id = 0,
                        Name = name,
                        Value = callBack.Address
                    });
                }
                else
                {
                    settings.Add(getSettings.SingleOrDefault(s => s.Name == name));
                }
            }

            return View(settings);
        }
    }
}
