using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.CharityModelDTO;
using TSTB.BLL.Services.Charity;
using TSTB.DAL.Models.Charity;
using TSTB.DAL.Models.User;
using TSTB.Web.Areas.Employee.Models;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharityAPIController : ControllerBase
    {
        private readonly ICharityService _charityService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPaymentCharityService _paymentCharityService;

        public CharityAPIController(ICharityService charityService,UserManager<ApplicationUser> userManager, IPaymentCharityService paymentCharityService)
        {
            _charityService = charityService;
            _userManager = userManager;
            _paymentCharityService = paymentCharityService;
        }

        // GET: api/CharityAPI
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<CharityDTO>(_charityService.GetAllCharities().AsQueryable(), loadOptions);
        }

        [HttpGet("Publish")]
        public object Publish(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<CharityDTO>(_charityService.GetAllPublishCharities().AsQueryable(), loadOptions);
        }

        [HttpGet("GetDetails")]
        public async Task<object> GetDetails(DataSourceLoadOptions loadOptions, int charId)
        {
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                return null;
            }else
            {
                return DataSourceLoader.Load<PaymentCharity>(_paymentCharityService.GetCharityDerails(charId, user.Id).AsQueryable(), loadOptions);
                

            }

        }

        [HttpGet("GetAllCharities")]
        public async Task<object> GetAllCharities(DataSourceLoadOptions loadOptions)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return null;
            }
            else
            {
                return DataSourceLoader.Load<PaymentCharity>(_paymentCharityService.GetAllCharityByUser(user.Id).AsQueryable(), loadOptions);
            }

        }
        

        // DELETE: api/CharityAPI/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(int id)
        {
            await _charityService.RemoveCharityById(id);
        }
    }
}