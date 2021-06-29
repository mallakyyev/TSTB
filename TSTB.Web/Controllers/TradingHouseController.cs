using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.Services.TradingHouses;

namespace TSTB.Web.Controllers
{
    public class TradingHouseController : Controller
    {
        private readonly ITradingHouseService _tradingHouseService;

        public TradingHouseController(ITradingHouseService tradingHouseService)
        {
            _tradingHouseService = tradingHouseService;
        }

        public IActionResult Index()
        {
            var tradingHouses = _tradingHouseService.GetAllPublishTradingHouses();
            return View(tradingHouses);
        }
    }
}
