using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.ProjectsModelDTO;
using TSTB.BLL.Services.Projects;
using TSTB.DAL.Models.Projects;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAPIController : ControllerBase
    {
        private readonly IProjectsService _projectService;
        
        public ProjectAPIController(IProjectsService projectsService)
        {
            _projectService = projectsService;
        }

        // GET: api/ProjectAPI
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<ProjectDTO>(_projectService.GetAllProjects().AsQueryable(), loadOptions);
        }

        // GET: api/ProjectAPI/GetAllPublishProjects
        [HttpGet("GetAllPublishProjects")]
        public object GetAllPublishProjects(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<ProjectDTO>(_projectService.GetAllPublishProjects().AsQueryable(), loadOptions);
        }

        // POST: api/ProjectAPI
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromForm] CreateProjectDTO value)
        {
            if (ModelState.IsValid)
            {
                await _projectService.CreateProject(value);
                return Ok(value);
            }
            return BadRequest();
        }

        // PUT: api/ProjectAPI/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Put([FromBody] EditProjectsDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _projectService.EditProject(value);
            return Ok(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(int id)
        {
            await _projectService.RemoveProject(id);
        }

        // DELETE: api/ProjectAPI
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task Delete()
        {
            await _projectService.RemoveAllProjects();
        }

        // GET: api/ProjectAPI/GetAllActiveProjects
        [HttpGet("GetAllActiveProjects")]
        public object GetAllActiveProjects(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<ProjectDTO>(_projectService.GetAllActiveProjects().AsQueryable(), loadOptions);
        }

        // GET: api/ProjectAPI/GetAllCompletedProjects
        [HttpGet("GetAllCompletedProjects")]
        public object GetAllCompletedProjects(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<ProjectDTO>(_projectService.GetAllCompletedProjects().AsQueryable(), loadOptions);
        }
    }
}