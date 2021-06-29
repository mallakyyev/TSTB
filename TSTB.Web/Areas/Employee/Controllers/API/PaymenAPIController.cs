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
using TSTB.BLL.ViewModel;
using TSTB.DAL.Models.User;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Employee.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymenAPIController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public PaymenAPIController(IEmployeeService employeeService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _employeeService = employeeService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: api/PaymenAPI
        [HttpGet]
        public async Task<object> GetAsync(DataSourceLoadOptions loadOptions)
        {
            var user = await _userManager.GetUserAsync(User);
            string id = user.Id;
            var payments = _employeeService.getAllPaymentByUserId(id).AsQueryable();
            return DataSourceLoader.Load<PaymentDTO>(payments, loadOptions);
        }

        // GET: api/PaymenAPI/GetAllTransactions
        [HttpGet("GetAllTransactions")]
        public async Task<object> GetAllTransactions(DataSourceLoadOptions loadOptions)
        {       
            return DataSourceLoader.Load<TransactionViewModel>(await _employeeService.getAllTransactions(), loadOptions);
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

        // PUT: api/PaymenAPI/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] EditPaymentDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _employeeService.EditPayment(value);
            return Ok(value);
        }

        // DELETE: api/PaymenAPI/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _employeeService.DeletePaymentById(id);
        }

    }
}