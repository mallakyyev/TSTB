using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.OnlineTradeDTO;
using TSTB.BLL.Services.OnlineTrading;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineTradingAPIController : ControllerBase
    {
        private readonly IOnlineTradingService _onlineTrService;
        public OnlineTradingAPIController(IOnlineTradingService onlineTradingService)
        {
            _onlineTrService = onlineTradingService;
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<OnlineTradingDTO>(_onlineTrService.GetAllOnlineTradings().AsQueryable(), loadOptions);
        }

        [HttpGet("Activity")]
        public object Activity(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<OnlineTradingActivityTypeDTO>(_onlineTrService.GetAllOnlineTradingActivityTypes().AsQueryable(), loadOptions);
        }

        [HttpGet("Categories")]
        public object Categories(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<OnlineTradingCategoryDTO>(_onlineTrService.GetAllOnlineTradingCategories().AsQueryable(), loadOptions);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(int id)
        {
            await _onlineTrService.DeleteOnlineTradingById(id);
        }

        [HttpDelete("DeleteActivity/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteActivity(int id)
        {
            await _onlineTrService.DeleteActivityById(id);
        }

        [HttpDelete("DeleteCategory/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteCategory(int id)
        {
            await _onlineTrService.DeleteCategoryById(id);
        }
    }
}