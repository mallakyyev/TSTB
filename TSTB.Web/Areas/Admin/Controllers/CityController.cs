using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.CallBackModelDTO;
using TSTB.BLL.Services.CallBacks;
using TSTB.BLL.Services.Language;
using Microsoft.AspNetCore.Authorization;
namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public CityController(ICityService cityService, ILanguageService languageService, IMapper mapper)
        {
            _cityService = cityService;
            _languageService = languageService;
            _mapper = mapper;
        }
        // GET: Admin/City
        public IActionResult Index()
        {
            return View();
        }


        // GET: Admin/City/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        // Post: Admin/City/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCityDTO city)
        {
            if (ModelState.IsValid)
            {
                await _cityService.CreateCity(city);

                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(city);
        }

        [HttpGet]
        // GET: Admin/City/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var serviceForEdit = await _cityService.GetCityForEditById(id);
            if (serviceForEdit == null)
            {
                return NotFound();
            }

            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);


            return View(serviceForEdit);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditCityDTO editCityDTO)
        {
            if (ModelState.IsValid)
            {
                await _cityService.EditCity(editCityDTO);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);

            return View(editCityDTO);
        }

        // GET: Admin/City/Delete/5
        public IActionResult Delete(int? id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }
    }
}