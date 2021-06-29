using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.AdvertisementDTO;
using TSTB.BLL.Services.AdvertisementService;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementAPIController : ControllerBase
    {
        private readonly IAdvertisementService _advertisementService;
        
        public AdvertisementAPIController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<AdvertisementDTO>(_advertisementService.GetAllAdvertisements().AsQueryable(), loadOptions);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _advertisementService.DeleteAdvertisementsById(id);
        }
    }
}