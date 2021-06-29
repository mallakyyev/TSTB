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
    public class NewsPaperDataController : Controller
    {
        private INewsPaperService _newsPaperService;
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public NewsPaperDataController(INewsPaperService newsPaperService, ILanguageService languageService, IMapper mapper)
        {
            _newsPaperService = newsPaperService;
            _languageService = languageService;
            _mapper = mapper;
        }

        // GET: Admin/NewsPaperData
        public IActionResult Index()
        {
            return View();
        }


        // GET: Admin/NewsPaperData/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        // Post: Admin/NewsPaperData/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNewsPaperDataDTO createNPDTO)
        {
            if (ModelState.IsValid)
            {
                await _newsPaperService.CreateNewsPaperData(createNPDTO);

                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(createNPDTO);
        }

        [HttpGet]
        // GET: Admin/NewsPaperData/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var newsPaperForEdit = await _newsPaperService.GetNewsPaperDataForEditById(id);
            if (newsPaperForEdit == null)
            {
                return NotFound();
            }

            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            //ViewBag.CategorySelection = new SelectList(_categoryService.GetAllCategory(), "Id", "Name", category.ParentCategoryId);

            return View(newsPaperForEdit);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditNewsPaperDataDTO editNewsDataDTO)
        {
            if (ModelState.IsValid)
            {
                await _newsPaperService.EditNewsPaperData(editNewsDataDTO);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);

            return View(editNewsDataDTO);
        }

        // GET: Admin/NewsPaperData/Delete/5
        public IActionResult Delete(int? id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }
    }
}