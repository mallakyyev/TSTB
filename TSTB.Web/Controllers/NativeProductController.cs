using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.Services.NativeProductionService;

namespace TSTB.Web.Controllers
{
    public class NativeProductController : Controller
    {
        private readonly INativeProductionService _nativeProductionService;

        public NativeProductController(INativeProductionService nativeProductionService)
        {
            _nativeProductionService = nativeProductionService;
        }

        public IActionResult Index()
        {
            var nativeProducts = _nativeProductionService.GetAllNativeProductions();
            return View(nativeProducts);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var result = await _nativeProductionService.GetNativeProdutionById(id);

            return View(result);
        }
    }
}
