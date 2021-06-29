using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.ServicesDTO;
using TSTB.BLL.Services.Language;
using TSTB.BLL.Services.Services;
using Microsoft.AspNetCore.Authorization;
namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class ServiceTypeController : Controller
    {
        private readonly IServicesTypeService _stService;
        private readonly ILanguageService _languageService;

        public ServiceTypeController(IServicesTypeService stService, ILanguageService langService)
        {
            _stService = stService;
            _languageService = langService;

        }
        // GET: Admin/ServiceType
        public IActionResult Index()
        {
            return View();
        }


        // GET: Admin/ServiceType/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        // Post: Admin/ServiceType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateServiceTypeDTO st)
        {
            if (ModelState.IsValid)
            {
                await _stService.CreateServiceType(st);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(st);
        }

        [HttpGet]
        // GET: Admin/ServiceType/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dept = await _stService.GetServiceTypeForEditById(id);

            if (dept == null)
            {
                return NotFound();

            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(dept);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditServiceTypeDTO pr)
        {
            if (ModelState.IsValid)
            {
                await _stService.EditServiceType(pr);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);

            return View(pr);
        }

        // GET: Admin/ServiceType/Delete/5
        public IActionResult Delete(int? id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }
    }
}