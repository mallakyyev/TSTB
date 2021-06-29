using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.Services.Tariff;
using TSTB.DAL.Models.Billing;
using TSTB.DAL.Models.User;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Employee.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TariffAPIController : ControllerBase
    {
        private readonly ITariffService _tariffService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public TariffAPIController(ITariffService tariffService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _tariffService = tariffService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: api/TariffAPI
        [HttpGet]
        public object GetAsync(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<Tariff>(_tariffService.getAllTariffs().AsQueryable(), loadOptions);
        }


       

         //POST: api/AccountantAPI
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tariff value)
        {
            if (ModelState.IsValid)
            {
                await _tariffService.CreateTariff(value);
                return Ok(value);
            }
            return BadRequest();
        }

        // PUT: api/AccountantAPI/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Tariff value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(value.Id != id)
            {
                return BadRequest();
            }
            await _tariffService.EditTariff(value);
            return Ok(value);
        }

        // DELETE: api/AccountantAPI/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _tariffService.DeleteTariffById(id);
        }

    }
}