using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.WidgetModelDTO;
using TSTB.BLL.Services.WidgetService;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetAPIController : ControllerBase
    {
        private readonly IWidgetService _widgetService;
        public WidgetAPIController(IWidgetService widgetService)
        {
            _widgetService = widgetService;
        }

        // GET: api/WidgetAPI
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<WidgetDTO>(_widgetService.GetAllWidgets().AsQueryable(), loadOptions);
        }

        // GET: api/WidgetAPI/GetAllPublishIndustry
        [HttpGet("GetAllPublishIndustry")]
        public object GetAllPublishIndustry(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<WidgetDTO>(_widgetService.GetAllPublishWidgets().AsQueryable(), loadOptions);
        }

        // GET: api/IndustriAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            WidgetDTO ind = await _widgetService.GetWidgetByIdAsync(id);
            return Ok(ind);
        }


        // POST: api/IndustriAPI
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromForm] CreateWidgetDTO value)
        {
            if (ModelState.IsValid)
            {
                await _widgetService.CreateWidget(value);
                return Ok(value);
            }
            return BadRequest();
        }

        // PUT: api/IndustriAPI/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] EditWidgetDTo value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _widgetService.EditWidget(value);
            return Ok(value);
        }

        // DELETE: api/IndustriAPI/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(int id)
        {
            await _widgetService.RemoveWidget(id);
        }

        // DELETE: api/IndustriAPI
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task Delete()
        {
            await _widgetService.RemoveAllWidgets();
        }
    }
}