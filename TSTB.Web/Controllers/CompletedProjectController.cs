using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.Services.Projects;

namespace TSTB.Web.Controllers
{
    public class CompletedProjectController : Controller
    {
        private readonly IProjectsService _projectsService;

        public CompletedProjectController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        public IActionResult Index()
        {
            var projects = _projectsService.GetAllPublishProjects();
            return View(projects);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var project = await _projectsService.GetProjectByIdAsync(id);
            return View(project);
        }
    }
}
