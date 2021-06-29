using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.Services.Industry;

namespace TSTB.Web.Controllers
{
    public class IndustryController : Controller
    {
        private readonly IIndustryService _industryService;

        public IndustryController(IIndustryService industryService)
        {
            _industryService = industryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {
            var result = await _industryService.GetIndustryByIdAsync(id);

            return View(result);
        }
    }
}
