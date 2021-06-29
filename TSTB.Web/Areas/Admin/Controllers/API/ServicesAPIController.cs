using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.ServicesDTO;
using TSTB.BLL.Services.Services;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesAPIController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IServicesTypeService _typeService;

        public ServicesAPIController(IServiceService serviceService, IServicesTypeService typeService)
        {
            _serviceService = serviceService;
            _typeService = typeService;
        }

        // GET: api/ServicesAPI
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<ServiceDTO>(_serviceService.GetAllServices().AsQueryable(), loadOptions);
        }

        // GET: api/ServicesAPI/GetAllPublishServices
        [HttpGet("GetAllPublishServices")]
        public object GetAllPublishServices(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<ServiceDTO>(_serviceService.GetAllPublishServices().AsQueryable(), loadOptions);
        }



        // POST: api/ServicesAPI
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromForm] CreateServiceDTO value)
        {
            if (ModelState.IsValid)
            {
                await _serviceService.CreateService(value);
                return Ok(value);
            }
            return BadRequest();
        }

        // PUT: api/ServicesAPI/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] EditServiceDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _serviceService.EditService(value);
            return Ok(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(int id)
        {
            await _serviceService.RemoveService(id);
        }

        // DELETE: api/ServicesAPI
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task Delete()
        {
            await _serviceService.RemoveAllServices();
        }

//-----------------------------------------------------------------------------------------------------
    // This part of the code will be handling ServiceType service requests
//-----------------------------------------------------------------------------------------------------

        // GET: api/ServicesAPI/ServiceTypes
        [HttpGet("ServiceTypes")]
        public object ServiceTypes(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<ServiceTypeDTO>(_typeService.GetAllServiceTypes().AsQueryable(), loadOptions);
        }

        // GET: api/ServicesAPI/ServiceTypesPublish
        [HttpGet("ServiceTypesPublish")]
        public object ServiceTypesPublish(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<ServiceTypeDTO>(_typeService.GetAllPublishServiceTypes().AsQueryable(), loadOptions);
        }

        // GET: api/ServicesAPI/ServiceTypes/{id}
        [HttpGet("ServiceTypes/{id}")]
        public object ServiceTypes(DataSourceLoadOptions loadOptions, int id)
        {
            return DataSourceLoader.Load<ServiceTypeDTO>(_typeService.GetAllServiceTypesByServiceId(id).AsQueryable(), loadOptions);
        }

        // POST: api/ServicesAPI/ServiceTypes
        [HttpPost("ServiceTypes")]
        public async Task<IActionResult> ServiceTypes([FromForm] CreateServiceTypeDTO value)
        {
            if (ModelState.IsValid)
            {
                await _typeService.CreateServiceType(value);
                return Ok(value);
            }
            return BadRequest();
        }

        // PUT: api/ServicesAPI/ServiceTypes/5
        [HttpPut("ServiceTypes/{id}")]
        public async Task<IActionResult> ServiceTypes([FromBody] EditServiceTypeDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _typeService.EditServiceType(value);
            return Ok(value);
        }

        // DELETE: api/ServicesAPI/ServiceTypes/5
        [HttpDelete("ServiceTypes/{id}")]
        public async Task ServiceTypes(int id)
        {
            await _typeService.RemoveServiceTypes(id);
        }

        // DELETE: api/ServicesAPI/ServiceTypes
        [HttpDelete("ServiceTypes")]
        public async Task ServiceTypes()
        {
            await _typeService.RemoveAllServiceTypes();
        }

    }
}