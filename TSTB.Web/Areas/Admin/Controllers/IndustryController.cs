using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.IndustryModelDTO;
using TSTB.BLL.Services.Industry;
using TSTB.BLL.Services.Language;
using Microsoft.AspNetCore.Authorization;
namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class IndustryController : Controller
    {
     
        private readonly IIndustryService _industryService;
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public IndustryController(IIndustryService industryService, ILanguageService languageService, IMapper mapper)
        {
            _industryService = industryService;
            _languageService = languageService;
            _mapper = mapper;
        }
        // GET: Admin/Industry
        public IActionResult Index()
        {
            return View();
        }


        // GET: Admin/Industry/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        // Post: Admin/Industry/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateIndustryDTO industryDTO)
        {
            if (ModelState.IsValid)
            {
                await _industryService.CreateIndustry(industryDTO);

                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(industryDTO);
        }

        [HttpGet]
        // GET: Admin/Industry/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var serviceForEdit = await _industryService.GetIndustryForEditById(id);
            if (serviceForEdit == null)
            {
                return NotFound();
            }

            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);


            return View(serviceForEdit);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditIndustryDTO editIndustryDTO)
        {
            if (ModelState.IsValid)
            {
                await _industryService.EditIndustry(editIndustryDTO);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);

            return View(editIndustryDTO);
        }

        // GET: Admin/Industry/Delete/5
        public IActionResult Delete(int? id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }
    }
}