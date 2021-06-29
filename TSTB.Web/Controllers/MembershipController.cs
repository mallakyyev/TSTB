using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.Services.Tariff;

namespace TSTB.Web.Controllers
{
    public class MembershipController : Controller
    {
        private readonly ITariffService _tariffService;

        public MembershipController(ITariffService tariffService)
        {
            _tariffService = tariffService;
        }

        public IActionResult Index()
        {
            var tariffs = _tariffService.getAllTariffs().OrderBy(o => o.Id);
            return View(tariffs);
        }
    }
}
