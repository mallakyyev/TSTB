using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.BannerModelDTO;
using TSTB.BLL.DTOs.LanguageDTO;
using TSTB.BLL.Services.Banner;
using TSTB.BLL.Services.Language;
using Microsoft.AspNetCore.Authorization;
namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public BannerController(IBannerService bannerService, ILanguageService languageService, IMapper mapper)
        {
            _bannerService = bannerService;
            _languageService = languageService;
            _mapper = mapper;
        }
        // GET: Admin/NewsPaper
        public IActionResult Index()
        {
            return View();
        }


        // GET: Admin/NewsPaper/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);

            return View();
        }

        // Post: Admin/Banner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBannerDTO createBannerDTO)
        {
            if (ModelState.IsValid)
            {
                await _bannerService.CreateBanner(createBannerDTO);

                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(createBannerDTO);
        }

        [HttpGet]
        // GET: Admin/Banner/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var bannerForEdit = await _bannerService.GetBannerForEditByIdAsync(id);
            if (bannerForEdit == null)
            {
                return NotFound();
            }

            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            //ViewBag.CategorySelection = new SelectList(_categoryService.GetAllCategory(), "Id", "Name", category.ParentCategoryId);

            return View(bannerForEdit);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditBannerDTO editBannerDTO)
        {
            if (ModelState.IsValid)
            {
                await _bannerService.EditBanner(editBannerDTO);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);

            return View(editBannerDTO);
        }

        // GET: Admin/Banner/Delete/5
        public IActionResult Delete(int? id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }
    }
}
