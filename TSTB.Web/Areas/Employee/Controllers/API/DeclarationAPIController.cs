using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TSTB.BLL.DTOs.BillingModelDTO;
using TSTB.BLL.Services.Employee;
using TSTB.DAL.Models.Billing;
using TSTB.DAL.Models.User;
using TSTB.Web.Areas.Identity.Pages.Account;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Employee.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeclarationAPIController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        public DeclarationAPIController(IEmployeeService employeeService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _employeeService = employeeService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: api/DeclarationAPI
        [HttpGet]
        public async Task<object> GetAsync(DataSourceLoadOptions loadOptions)
        {
            var user = await _userManager.GetUserAsync(User);
            string id = user.Id;
            return DataSourceLoader.Load<DeclarationDTO>(_employeeService.getAllDeclarationByUserId(id).AsQueryable(), loadOptions);
        }


        //// POST: api/DeclarationAPI
        //[HttpPost]
        //public async Task<IActionResult> Post([FromForm] CreateDeclarationDTO value)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _employeeService.CreateDeclaration(value);
        //        return Ok(value);
        //    }
        //    return BadRequest();
        //}

        // PUT: api/DeclarationAPI/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] EditDeclarationDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _employeeService.EditDeclaration(value);
            return Ok(value);
        }

        // DELETE: api/DeclarationAPI/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _employeeService.DeleteDeclarationById(id);
        }

        // DELETE: api/DeclarationAPI/DeleteDeclartionFiles
        [HttpDelete("DeleteDeclartionFiles/{id}")]
        public async Task DeleteDeclartionFiles(int id)
        {
            await _employeeService.DeleteDeclartionFilesById(id);
        }
        

        // Get: api/DeclarationAPI/GetDeclarationFiles/5
        [HttpGet("GetDeclarationFiles/{id}")]
        public object GetDeclarationFiles(DataSourceLoadOptions loadOptions, int id)
        {
            return DataSourceLoader.Load<DeclarationImage>(_employeeService.GetAllDeclarationImageByDecId(id).AsQueryable(), loadOptions);
        }

    }
}