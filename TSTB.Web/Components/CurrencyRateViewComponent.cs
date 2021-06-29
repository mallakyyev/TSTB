using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSTB.BLL.Services.CurrencyRateService;
using TSTB.DAL.Models.CurrencyRate;

namespace TSTB.Web.Components
{
    public class CurrencyRateViewComponent : ViewComponent
    {
        private readonly ICuurencyRateService _currencyRateService;
        public CurrencyRateViewComponent(ICuurencyRateService cuurencyRateService)
        {
            _currencyRateService = cuurencyRateService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CurrencyRate> r = new List<CurrencyRate>(await _currencyRateService.GetCurrentCurrencyRate());
            return View(r);

        }
    }
}
