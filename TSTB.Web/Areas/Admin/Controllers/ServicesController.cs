using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.ServicesDTO;
using TSTB.BLL.Services.Language;
using TSTB.BLL.Services.Services;

namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class ServicesController : Controller
    {
        private readonly IServiceService _servicesService;
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public ServicesController(IServiceService services, ILanguageService languageService, IMapper mapper)
        {
            _servicesService = services;
            _languageService = languageService;
            _mapper = mapper;
        }
        // GET: Admin/Services
        public IActionResult Index()
        {
            return View();
        }


        // GET: Admin/Services/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        // Post: Admin/Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateServiceDTO service)
        {
            if (ModelState.IsValid)
            {
                await _servicesService.CreateService(service);

                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(service);
        }

        [HttpGet]
        // GET: Admin/Services/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var serviceForEdit = await _servicesService.GetServiceForEditById(id);
            if (serviceForEdit == null)
            {
                return NotFound();
            }

            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
          

            return View(serviceForEdit);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditServiceDTO editServiceDTO)
        {
            if (ModelState.IsValid)
            {
                await _servicesService.EditService(editServiceDTO);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);

            return View(editServiceDTO);
        }

        // GET: Admin/Services/Delete/5
        public IActionResult Delete(int? id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }
    }
}