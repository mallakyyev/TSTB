using System;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TSTB.BLL.DTOs.ProjectsModelDTO;
using TSTB.BLL.Services.Language;
using TSTB.BLL.Services.Projects;
using TSTB.DAL.Models.Projects;
using TSTB.Web.Data;

namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class ProjectController : Controller
    {
        private readonly IProjectsService _projectService;
        private readonly ILanguageService _languageService;

        public ProjectController(IProjectsService depService, ILanguageService langService)
        {
            _projectService = depService;
            _languageService = langService;

        }
        // GET: Admin/Project
        public IActionResult Index()
        {
            return View();
        }


        // GET: Admin/Project/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        // Post: Admin/Project/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProjectDTO projects)
        {
            if (ModelState.IsValid)
            {
                await _projectService.CreateProject(projects);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(projects);
        }

        [HttpGet]
        // GET: Admin/Project/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dept = await _projectService.GetProjectForEditById(id);
            
            if (dept == null)
            {
                return NotFound();
                
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(dept);
        }

       
        [HttpPost]
        public async Task<IActionResult> Edit(EditProjectsDTO pr)
        {
            if (ModelState.IsValid)
            {
                await _projectService.EditProject(pr);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);

            return View(pr);
        }

        // GET: Admin/Project/Delete/5
        public IActionResult Delete(int? id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

       
    }
}