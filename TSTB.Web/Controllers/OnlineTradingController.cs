using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.Services.OnlineTrading;

namespace TSTB.Web.Controllers
{
    public class OnlineTradingController : Controller
    {
        private readonly IOnlineTradingService _onlineTradingService;

        public OnlineTradingController(IOnlineTradingService onlineTradingService)
        {
            _onlineTradingService = onlineTradingService;
        }

        public IActionResult Index()
        {
            var result = _onlineTradingService.GetAllOnlineTradings().GroupBy(p => p.CityName).SelectMany(grouping => grouping.OrderBy(b => b.ActivityTypeName));
            
            return View(result);
        }
    }
}
