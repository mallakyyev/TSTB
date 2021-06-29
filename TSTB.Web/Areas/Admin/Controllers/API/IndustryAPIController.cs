using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.IndustryModelDTO;
using TSTB.BLL.Services.Industry;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustryAPIController : ControllerBase
    {
        private readonly IIndustryService _industryService;
        public IndustryAPIController(IIndustryService industryService)
        {
            _industryService = industryService;
        }

        // GET: api/IndustriAPI
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<IndustryDTO>(_industryService.GetAllIndustry().AsQueryable(), loadOptions);
        }

        // GET: api/IndustriAPI/GetAllPublishIndustry
        [HttpGet("GetAllPublishIndustry")]
        public object GetAllPublishIndustry(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<IndustryDTO>(_industryService.GetAllPublishIndustry().AsQueryable(), loadOptions);
        }

        // GET: api/IndustriAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            IndustryDTO ind = await _industryService.GetIndustryByIdAsync(id);
            return Ok(ind);
        }


        // POST: api/IndustriAPI
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromForm] CreateIndustryDTO value)
        {
            if (ModelState.IsValid)
            {
                await _industryService.CreateIndustry(value);
                return Ok(value);
            }
            return BadRequest();
        }

        // PUT: api/IndustriAPI/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put( [FromBody] EditIndustryDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _industryService.EditIndustry(value);
            return Ok(value);
        }

        // DELETE: api/IndustriAPI/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(int id)
        {
            await _industryService.RemoveIndustry(id);
        }

        // DELETE: api/IndustriAPI
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task Delete()
        {
            await _industryService.RemoveAllINdustries();
        }
    }
}
