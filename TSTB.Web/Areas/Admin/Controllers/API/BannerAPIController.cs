using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.BannerModelDTO;
using TSTB.BLL.Services.Banner;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerAPIController : ControllerBase
    {
        private readonly IBannerService _bannerService;
        public BannerAPIController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }



        // GET: api/BannerAPI
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<BannerDTO>(_bannerService.GetAllBanners().AsQueryable(), loadOptions);
        }


        // GET: api/BannerAPI/GetAllPublich
        [HttpGet("GetAllPublich")]
        public object GetAllPublich(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<BannerDTO>(_bannerService.GetAllPublishBanners().AsQueryable(), loadOptions);
        }

        // GET: api/BannerAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            BannerDTO dept = await _bannerService.GetBannerByIdAsync(id);
            return Ok(dept);
        }


        // DELETE: api/BannerAPI/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _bannerService.RemoveBannerById(id);
        }
    }
}
