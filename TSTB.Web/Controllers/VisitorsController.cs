using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.Services.VisitorsService;
using TSTB.BLL.ViewModel;

namespace TSTB.Web.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly IVisitorsService _visitorsService;
        public VisitorsController(IVisitorsService visitorsService)
        {
            _visitorsService = visitorsService;
        }
        public IActionResult Index()
        {
            List<CountryCount> res = new List<CountryCount>( _visitorsService.GetCountriesByCount() );
            return View(res);
        }
        public IActionResult Monthly()
        {
            List<CountryCount> res = new List<CountryCount>(_visitorsService.GetMonthlyCount());
            return View(res);
        }

        public IActionResult Yearly()
        {
            List<YearlyCount> res = new List<YearlyCount>(_visitorsService.GetYearlyCounts());
            return View(res);
        }
        public IActionResult General()
        {
            List<CountryCount> res = new List<CountryCount>(_visitorsService.GetGeneral());
            return View(res);
        }
    }
}