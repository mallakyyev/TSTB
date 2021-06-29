using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSTB.BLL.DTOs.DepartmentModelDTO;
using TSTB.BLL.Services.Departments;
using TSTB.BLL.Services.Language;
using TSTB.DAL.Models.Departments;
using TSTB.Web.Data;

namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentsService _departmentsService;
        private readonly ILanguageService _languageService;

        public DepartmentController(IDepartmentsService depService , ILanguageService langService)
        {
            _departmentsService = depService;
            _languageService = langService;
        }

        // GET: Admin/Department
        public IActionResult Index()
        {
            return View();
        }


        // GET: Admin/Department/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        // Post: Admin/Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDepartmentDTO departments)
        {
            if (ModelState.IsValid)
            {
                await _departmentsService.CreateDeparment(departments);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);    
            return View(departments);
        }

        [HttpGet]
        // GET: Admin/Department/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dept = await _departmentsService.GetDepartmentForEditByIdAsync(id);
            if(dept == null )
            {
                return NotFound();
;            }

            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            //ViewBag.CategorySelection = new SelectList(_categoryService.GetAllCategory(), "Id", "Name", category.ParentCategoryId);

            return View(dept);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditDepartmentDTO dept)
        {
            if (ModelState.IsValid)
            {
                await _departmentsService.EditDepartment(dept);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);

            return View(dept);
        }

        // GET: Admin/Department/Delete/5
        public IActionResult Delete(int? id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

    }
}
