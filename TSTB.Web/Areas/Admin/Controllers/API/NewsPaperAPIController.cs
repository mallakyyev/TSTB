using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.NewsPaperModelDTO;
using TSTB.BLL.Services.NewsPaper;
using TSTB.DAL.Models.NewsPapers;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsPaperAPIController : ControllerBase
    {
        private readonly INewsPaperService _newsPaperService;
        public NewsPaperAPIController(INewsPaperService newsPaperService)
        {
            _newsPaperService = newsPaperService;
        }

        // GET: api/NewsPaperAPI
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<NewsPaperDTO>(_newsPaperService.GetAllNewsPapers().AsQueryable(), loadOptions);
        }

        // GET: api/NewsPaperAPI/GetAllPublish
        [HttpGet("GetAllPublish")]
        public object GetAllPublish(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<NewsPaperDTO>(_newsPaperService.GetAllPublishNewsPapers().AsQueryable(), loadOptions);
        }

        // GET: api/NewsPaperAPI/GetNewsPaperFiles/id
        [HttpGet("GetNewsPaperFiles/{id}")]
        public object GetNewsPaperFiles(DataSourceLoadOptions loadOptions, int id)
        {
            return DataSourceLoader.Load<NewsPaperFiles>(_newsPaperService.GetNewsPaperFileById(id).AsQueryable(), loadOptions);
        }

        // GET: api/NewsPaperAPI/DeleteNewsPaperFiles/id
        [HttpDelete("DeleteNewsPaperFiles/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteNewsPaperFilesAsync( int id)
        {
            await _newsPaperService.RemoveNewsPaperFileById(id);

        }

        // GET: api/NewsPaperAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            NewsPaperDTO pg = await _newsPaperService.GetNewsPaperByIdAsync(id);
            return Ok(pg);
        }


        // POST: api/NewsPaperAPI
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromForm] CreateNewsPaperDTO value)
        {
            if (ModelState.IsValid)
            {
                await _newsPaperService.CreateNewsPaper(value);
                return Ok(value);
            }
            return BadRequest();
        }

        // PUT: api/NewsPaperAPI/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] EditNewsPaperDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _newsPaperService.EditNewsPaper(value);
            return Ok(value);
        }

        // DELETE: api/NewsPaperAPI/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(int id)
        {
            await _newsPaperService.RemoveNewsPaperById(id);
        }

        /////////////////////////////////////////////////////////////////////////////
        ///             News Papard data and Files API Controller               ////
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
        ///


        // GET: api/NewsPaperAPI/Data
        [HttpGet("Data")]
        public object Data(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<NewsPaperDataDTO>(_newsPaperService.GetAllNewsPaperData().AsQueryable(), loadOptions);
        }

        // GET: api/NewsPaperAPI/GetAllPublishData
        [HttpGet("GetAllPublishData")]
        public object GetAllPublishData(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<NewsPaperDataDTO>(_newsPaperService.GetAllPublishNewsPaperData().AsQueryable(), loadOptions);
        }

        // GET: api/NewsPaperAPI/Data/5
        [HttpGet("Data/{id}")]
        public async Task<IActionResult> Data(int id)
        {
            var pg = await _newsPaperService.GetNewsPaperDataByIDAsync(id);
            return Ok(pg);
        }


        // POST: api/NewsPaperAPI/Data
        [HttpPost("Data")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Data([FromForm] CreateNewsPaperDataDTO value)
        {
            if (ModelState.IsValid)
            {
                await _newsPaperService.CreateNewsPaperData(value);
                return Ok(value);
            }
            return BadRequest();
        }

        // PUT: api/NewsPaperAPI/Data/5
        [HttpPut("Data/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Data([FromBody] EditNewsPaperDataDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _newsPaperService.EditNewsPaperData(value);
            return Ok(value);
        }

        // DELETE: api/NewsPaperAPI/DataDel/5
        [HttpDelete("DataDel/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DataDel(int id)
        {
            await _newsPaperService.RemoveNewsPaperData(id);
        }
    }
}