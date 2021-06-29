using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.NewsPaperModelDTO;
using TSTB.BLL.Services.Language;
using TSTB.BLL.Services.NewsPaper;
using Microsoft.AspNetCore.Authorization;
namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class NewsPaperController : Controller
    {
        private readonly INewsPaperService _newsPaperService;
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public NewsPaperController(INewsPaperService newsPaperService, ILanguageService languageService, IMapper mapper)
        {
            _newsPaperService = newsPaperService;
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

        // Post: Admin/NewsPaper/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNewsPaperDTO createNPDTO)
        {
            if (ModelState.IsValid)
            {
                await _newsPaperService.CreateNewsPaper(createNPDTO);

                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(createNPDTO);
        }

        [HttpGet]
        // GET: Admin/NewsPaper/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var newsCatForEdit = await _newsPaperService.GetNewsPaperForEditById(id);
            if (newsCatForEdit == null)
            {
                return NotFound();
            }

            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            //ViewBag.CategorySelection = new SelectList(_categoryService.GetAllCategory(), "Id", "Name", category.ParentCategoryId);

            return View(newsCatForEdit);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditNewsPaperDTO editNewsCatDTO)
        {
            if (ModelState.IsValid)
            {
                await _newsPaperService.EditNewsPaper(editNewsCatDTO);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);

            return View(editNewsCatDTO);
        }

        // GET: Admin/NewsPaper/Delete/5
        public IActionResult Delete(int? id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }
    }
}