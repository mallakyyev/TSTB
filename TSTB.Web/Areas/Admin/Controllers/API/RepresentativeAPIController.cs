using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.RepresentativesModelDTO;
using TSTB.BLL.Services.Representative;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentativeAPIController : ControllerBase
    {
        private readonly IRepresentativeService _representataiveService;
        public RepresentativeAPIController(IRepresentativeService representativeService)
        {
            _representataiveService = representativeService;
        }

        // GET: api/RepresentativeAPI
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<RepresentativeDTO>(_representataiveService.GetAllRepresentatives().AsQueryable(), loadOptions);
        }

        // GET: api/RepresentativeAPI/GetAllPublishCallBakcs
        [HttpGet("GetAllPublishCallBakcs")]
        public object GetAllPublishCallBakcs(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<RepresentativeDTO>(_representataiveService.GetAllPublishRepresentatives().AsQueryable(), loadOptions);
        }

        // POST: api/RepresentativeAPI
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromForm] CreateRepresentativeDTO value)
        {
            if (ModelState.IsValid)
            {
                await _representataiveService.CreateRepresentative(value);
                return Ok(value);
            }
            return BadRequest();
        }

        // PUT: api/RepresentativeAPI/5
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromForm] EditRepresentativeDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _representataiveService.EditRepresentative(value);
            return Ok(value);
        }

        // DELETE: api/RepresentativeAPI/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task Delete(int id)
        {
            await _representataiveService.RemoveRepresentative(id);
        }

        // GET: api/RepresentativeAPI/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            RepresentativeDTO callBack = await _representataiveService.GetRepresentativeByIdAsync(id);
            return Ok(callBack);
        }

        // GET: api/RepresentativeAPI/SearchRepresentativeByName/{name}
        [HttpGet("SearchRepresentativeByName/{name?}")]
        public object SearchRepresentativeByName(DataSourceLoadOptions loadOptions, string name="")
        {
            return DataSourceLoader.Load<RepresentativeDTO>(_representataiveService.SearchRepresentativeByName(name).AsQueryable(), loadOptions);
        }
    }
}