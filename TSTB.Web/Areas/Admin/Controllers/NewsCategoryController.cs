using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.NewsModelDTO;
using TSTB.BLL.Services.Language;
using TSTB.BLL.Services.NewsCategory;
using Microsoft.AspNetCore.Authorization;
namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class NewsCategoryController : Controller
    {
        private readonly INewsCategoryService _newsCategoryService;
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public NewsCategoryController(INewsCategoryService newsCategory, ILanguageService languageService, IMapper mapper)
        {
            _newsCategoryService = newsCategory;
            _languageService = languageService;
            _mapper = mapper;
        }
        // GET: Admin/NewsCategory
        public IActionResult Index()
        {
            return View();
        }


        // GET: Admin/NewsCategory/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        // Post: Admin/NewsCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNewsCategoryDTO newsCategory)
        {
            if (ModelState.IsValid)
            {
                await _newsCategoryService.CreateNewsCategory(newsCategory);

                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(newsCategory);
        }

        [HttpGet]
        // GET: Admin/NewsCategory/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var newsCatForEdit =   await _newsCategoryService.GetNewsCategoryForEditById(id);
            if (newsCatForEdit == null)
            {
                return NotFound();
            }

            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            //ViewBag.CategorySelection = new SelectList(_categoryService.GetAllCategory(), "Id", "Name", category.ParentCategoryId);

            return View(newsCatForEdit);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditNewsCategoryDTO editNewsCatDTO)
        {
            if (ModelState.IsValid)
            {
                await _newsCategoryService.EditNewsCategory(editNewsCatDTO);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);

            return View(editNewsCatDTO);
        }

        // GET: Admin/NewsCategory/Delete/5
        public IActionResult Delete(int? id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }
    }
}