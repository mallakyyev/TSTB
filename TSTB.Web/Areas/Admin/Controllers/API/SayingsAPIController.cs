using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.SayingsDTO;
using TSTB.BLL.Services.Sayings;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SayingsAPIController : ControllerBase
    {
        private readonly ISayingsService _sayingsService;
        public SayingsAPIController(ISayingsService sayingsService)
        {
            _sayingsService = sayingsService;
        }

        // GET: api/SayingsAPI
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<SayingsDTO>(_sayingsService.GetAllSayingsAsync(), loadOptions);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(int id)
        {
            await _sayingsService.RemoveSayings(id);
        }


    }
}