using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.BillingModelDTO;
using TSTB.BLL.Services.Employee;
using TSTB.BLL.Services.Tariff;
using TSTB.DAL.Models.Billing;
using TSTB.DAL.Models.User;
using TSTB.Web.Binder;
using Microsoft.AspNetCore.Mvc.Localization;

namespace TSTB.Web.Areas.Employee.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountantAPIController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ITariffService _tariffService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHtmlLocalizer<SharedResource> SharedLocalizer;
        public AccountantAPIController(IEmployeeService employeeService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITariffService tariffService, IHtmlLocalizer<SharedResource> SharedLocalizer_)
        {
            _employeeService = employeeService;
            _userManager = userManager;
            _signInManager = signInManager;
            _tariffService = tariffService;
            SharedLocalizer = SharedLocalizer_;
        }

        // GET: api/AccountantAPI
        [HttpGet]
        public object GetAsync(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<DeclarationAccount>(_employeeService.getAllDeclarationByStatus().AsQueryable(), loadOptions);
        }

        [HttpGet("GetAmounts")]
        public object GetAmounts()
        {
            return _tariffService.getAllTariffs();
        }
        // GET: api/AccountantAPI/GetImages
        [HttpGet("GetImages")]
        public object GetImages(DataSourceLoadOptions loadOptions, int  decId)
        {
            return DataSourceLoader.Load<DeclarationImage>(_employeeService.GetAllDeclarationImageByDecId(decId).AsQueryable(), loadOptions);
        }


        //// POST: api/AccountantAPI
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

        // PUT: api/AccountantAPI/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] EditDeclatarionAccountant value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(value.Amount <= 0 && value.StatusDeclaration == DAL.Models.Enums.StatusDeclaration.Confirmed)
            {
                return BadRequest("Amount cannot be empty or zeros!!");
            }
            if (value.Description == null && value.StatusDeclaration == DAL.Models.Enums.StatusDeclaration.Cancelled)
            {
                return BadRequest("Description cannot be empty or zeros!!");
            }
            if (value.StatusDeclaration == DAL.Models.Enums.StatusDeclaration.Confirmed)
                value.Description = null;
            bool isUpdated = await _employeeService.EditDeclarationAcc(value);
            if (!isUpdated)
            {
                return BadRequest("Cannot Update, The Declaration is alreade paid!!");    
            }
            return Ok(value);
        }
       

        // DELETE: api/AccountantAPI/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _employeeService.DeleteDeclarationById(id);
        }

       
    }
}