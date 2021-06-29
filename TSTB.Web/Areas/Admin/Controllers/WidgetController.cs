using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.WidgetModelDTO;
using TSTB.BLL.Services.Language;
using TSTB.BLL.Services.WidgetService;

namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class WidgetController : Controller
    {
        private readonly IWidgetService _widgetService;
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public  WidgetController (IWidgetService widgetService, ILanguageService languageService, IMapper mapper)
        {
            _widgetService = widgetService;
            _languageService = languageService;
            _mapper = mapper;
        }
        // GET: Admin/Widget
        public IActionResult Index()
        {
            return View();
        }


        // GET: Admin/Widget/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        // Post: Admin/Widget/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateWidgetDTO model)
        {
            if (ModelState.IsValid)
            {
                await _widgetService.CreateWidget(model);

                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(model);
        }

        [HttpGet]
        // GET: Admin/Widget/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var widgetForEdit = await _widgetService.GetWidgetForEditById(id);
            if (widgetForEdit == null)
            {
                return NotFound();
            }

            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);


            return View(widgetForEdit);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditWidgetDTo model)
        {
            if (ModelState.IsValid)
            {
                await _widgetService.EditWidget(model);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);

            return View(model);
        }

        // GET: Admin/Widget/Delete/5
        public IActionResult Delete(int? id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }
    }
}