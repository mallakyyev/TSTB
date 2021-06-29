using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.DepartmentModelDTO;
using TSTB.BLL.Services.CallBacks;
using TSTB.BLL.Services.Departments;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsAPIController : ControllerBase
    {
        private readonly IDepartmentsService _departmentsService;
        public DepartmentsAPIController(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }
      

       
        // GET: api/DepartmentsAPI
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<DepartmentDTO>(_departmentsService.GetAllDepartments().AsQueryable(), loadOptions);
        }


        // GET: api/DepartmentsAPI/GetAllPublichDepartments
        [HttpGet("GetAllPublichDepartments")]
        public object GetAllPublichDepartments(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<DepartmentDTO>(_departmentsService.GetAllPublishDepartments().AsQueryable(), loadOptions);
        }

        // GET: api/DepartmentsAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            DepartmentDTO dept =  await _departmentsService.GetDepartmentByIdAsync(id);
            return Ok(dept);
        }

        // POST: api/DepartmentsAPI
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromForm] CreateDepartmentDTO value)
        {
            if (ModelState.IsValid)
            {
                await _departmentsService.CreateDeparment(value);
                return Ok(value);
            }
            return BadRequest();
        }

        // PUT: api/DepartmentsAPI/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put([FromBody] EditDepartmentDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _departmentsService.EditDepartment(value);
            return Ok(value);
        }

        // DELETE: api/DepartmentsAPI/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(int id)
        {
            await _departmentsService.RemoveDepartment(id);
        }
    }
}
