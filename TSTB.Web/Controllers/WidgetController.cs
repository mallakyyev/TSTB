using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.Services.WidgetService;

namespace TSTB.Web.Controllers
{
    public class WidgetController : Controller
    {
        private readonly IWidgetService _widgetService;

        public WidgetController(IWidgetService widgetService)
        {
            _widgetService = widgetService;
        }

        public async Task<IActionResult> Index(int id)
        {
            var result = await _widgetService.GetWidgetByIdAsync(id);

            return View(result);
        }
    }
}
