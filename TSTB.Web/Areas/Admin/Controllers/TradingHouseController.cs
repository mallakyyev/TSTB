using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.TradingHousesDTO;
using TSTB.BLL.Services.Language;
using TSTB.BLL.Services.TradingHouses;

namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class TradingHouseController : Controller
    {
        private readonly ITradingHouseService _trHouseService;

        private readonly ILanguageService _languageService;

        public TradingHouseController(ITradingHouseService trHouseService, ILanguageService langService)
        {
            _trHouseService = trHouseService;

            _languageService = langService;

        }
        // GET: Admin/TradingHouse
        public IActionResult Index()
        {
            return View();
        }


        // GET: Admin/TradingHouse/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        // Post: Admin/TradingHouse/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTradingHouseDTO tr)
        {
            if (ModelState.IsValid)
            {
                await _trHouseService.CreateTradingHouse(tr);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(tr);
        }

        [HttpGet]
        // GET: Admin/TradingHouse/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dept = await _trHouseService.GetTradingHouseForEditById(id);

            if (dept == null)
            {
                return NotFound();

            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(dept);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditTradingHousesDTO tr)
        {
            if (ModelState.IsValid)
            {
                await _trHouseService.EditTradingHouse(tr);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);

            return View(tr);
        }

        // GET: Admin/TradingHouse/Delete/5
        public IActionResult Delete(int? id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }
    }
}