using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.NativeProductionsDTO;
using TSTB.BLL.Services.Language;
using TSTB.BLL.Services.NativeProductionService;

namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class NativeProductionController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly INativeProductionService _nativeProductionService;

        public NativeProductionController(ILanguageService languageService, INativeProductionService nativeProductionService)
        {
            _languageService = languageService;
            _nativeProductionService = nativeProductionService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNativeProductionDTO model)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            model.CreatedDate = DateTime.Today;
            if (ModelState.IsValid)
            {
                await _nativeProductionService.CreateNativeProduction(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public  async Task<IActionResult> Edit(int id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            EditNativeProductionDTO editN = await _nativeProductionService.GetNativeProductionForEditById(id);
            if(editN != null)
                return View(editN);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditNativeProductionDTO model)
        {
            if(ModelState.IsValid)
            {
                await _nativeProductionService.EditNativeProduction(model);
                return RedirectToAction("Index");
            }
            return View(model);
        } 
    }
}