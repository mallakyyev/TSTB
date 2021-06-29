using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.SayingsDTO;
using TSTB.BLL.Services.Language;
using TSTB.BLL.Services.Sayings;

namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class SayingsController : Controller
    {
        private readonly ISayingsService _sayingsService;
        private readonly ILanguageService _languageService;
        public SayingsController(ISayingsService sayingsService, ILanguageService languageService)
        {
            _sayingsService = sayingsService;
            _languageService = languageService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            EditSayingsDTO result = await _sayingsService.GetSayingsForEditByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditSayingsDTO model)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            if (ModelState.IsValid)
            {
                await _sayingsService.EditSayings(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSayingsDTO model)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            if (ModelState.IsValid)
            {
                await _sayingsService.CreateSayings(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}