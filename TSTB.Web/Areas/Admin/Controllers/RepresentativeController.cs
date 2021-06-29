using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.RepresentativesModelDTO;
using TSTB.BLL.Services.Language;
using TSTB.BLL.Services.Representative;
using Microsoft.AspNetCore.Authorization;
namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class RepresentativeController : Controller
    {
        private readonly IRepresentativeService _repService;
      
        private readonly ILanguageService _languageService;

        public RepresentativeController(IRepresentativeService repService, ILanguageService langService)
        {
            _repService = repService;
          
            _languageService = langService;

        }
        // GET: Admin/ Representative
        public IActionResult Index()
        {
            return View();
        }


        // GET: Admin/Representative/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        // Post: Admin/Representative/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRepresentativeDTO cb)
        {
            if (ModelState.IsValid)
            {
                await _repService.CreateRepresentative(cb);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(cb);
        }

        [HttpGet]
        // GET: Admin/Representative/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dept = await _repService.GetRepresentativeForEditById(id);

            if (dept == null)
            {
                return NotFound();

            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(dept);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditRepresentativeDTO pr)
        {
            if (ModelState.IsValid)
            {
                await _repService.EditRepresentative(pr);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);

            return View(pr);
        }

        // GET: Admin/Representative/Delete/5
        public IActionResult Delete(int? id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }
    }
}