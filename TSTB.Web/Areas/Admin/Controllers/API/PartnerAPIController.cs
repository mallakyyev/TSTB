using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.PartnersModelDTO;
using TSTB.BLL.Services.Partner;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerAPIController : ControllerBase
    {
        private readonly IPartnerService _partnerService;
        private readonly IPartnerDataService _dataService;
        public PartnerAPIController(IPartnerService parterService, IPartnerDataService dataService)
        {
            _partnerService = parterService;
            _dataService = dataService;
        }

        // GET: api/PartnerAPI
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<PartnersDTO>(_partnerService.GetAllPartners().AsQueryable(), loadOptions);
        }

        // GET: api/PartnerAPI/GetAllPublishPartners
        [HttpGet("GetAllPublishPartners")]
        public object GetAllPublishPartners(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<PartnersDTO>(_partnerService.GetAllPublishPartners().AsQueryable(), loadOptions);
        }

        // POST: api/PartnerAPI
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromForm] CreatePartnerDTO value)
        {
            if (ModelState.IsValid)
            {
                await _partnerService.CreatePartner(value);
                return Ok(value);
            }
            return BadRequest();
        }

        // PUT: api/PartnerAPI/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] EditPartnerDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _partnerService.EditPartner(value);
            return Ok(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(int id)
        {
            await _partnerService.RemovePartner(id); 
        }

        // DELETE: api/PartnerAPI
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task Delete()
        {
            await _partnerService.RemoveAllPartners();
        }
//-----------------------------------------------------------------------------------------------------
        // This part of the code will be handling PartnerData service requests
//-----------------------------------------------------------------------------------------------------
     
        // GET: api/PartnerAPI/Data
        [HttpGet("Data")]
        public object Data(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<PartnerDataDTO>(_dataService.GetAllPartnersData().AsQueryable(), loadOptions);
        }

        // GET: api/PartnerAPI/DataIsPublish
        [HttpGet("DataIsPublish")]
        public object DataIsPublish(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<PartnerDataDTO>(_dataService.GetAllPublishPartnersData().AsQueryable(), loadOptions);
        }

        /*
         //GET:  api/PartnerAPI/Data/id
        [HttpGet("Data/{id}")]
        public object Data(DataSourceLoadOptions loadOptions, int id)
        {
            return DataSourceLoader.Load<PartnerDataDTO>(_dataService.GetPartnerDataByPartnerId(id).AsQueryable(), loadOptions);
        }
        */

        // POST: api/PartnerAPI/CreateData
        [HttpPost("CreateData")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateData([FromForm] CreatePartnerDataDTO value)
        {
            if (ModelState.IsValid)
            {
                await _dataService.CreatePartnerData(value);
                return Ok(value);
            }
            return BadRequest();
        }

        // PUT: api/PartnerAPI/Edit/5
        [HttpPut("Edit/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit([FromBody] EditPartnerDataDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _dataService.EditPartnerData(value);
            return Ok(value);
        }


        // DELETE: api/PartnerAPI/DeleteData/{id}
        [HttpDelete("DeleteData/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteData(int id)
        {
            await _dataService.RemovePartnerData(id);
        }

        // DELETE: api/PartnerAPI/DeleteAllData
        [HttpDelete("DeleteAllData")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAllData()
        {
            await _dataService.RemoveAllPartnersData();
        }

    }
}