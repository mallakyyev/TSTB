using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.TradingHousesDTO;
using TSTB.BLL.Services.TradingHouses;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradingHouseAPIController : ControllerBase
    {
        private readonly ITradingHouseService _trHouseService;

        public TradingHouseAPIController(ITradingHouseService trHouseService)
        {
            _trHouseService = trHouseService;
        }

        // GET: api/TradingHouseAPI
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<TradingHouseDTO>(_trHouseService.GetAllTradingHouses().AsQueryable(), loadOptions);
        }

        // GET: api/TradingHouseAPI/GetAllPublishTradingHouses
        [HttpGet("GetAllPublishTradingHouses")]
        public object GetAllPublishTradingHouses(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<TradingHouseDTO>(_trHouseService.GetAllPublishTradingHouses().AsQueryable(), loadOptions);
        }

        // POST: api/TradingHouseAPI
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromForm] CreateTradingHouseDTO value)
        {
            if (ModelState.IsValid)
            {
                await _trHouseService.CreateTradingHouse(value);
                return Ok(value);
            }
            return BadRequest();
        }

        // PUT: api/TradingHouseAPI/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] EditTradingHousesDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _trHouseService.EditTradingHouse(value);
            return Ok(value);
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(int id)
        {
            await _trHouseService.RemoveTradingHouse(id);
        }

        // DELETE: api/TradingHouseAPI
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task Delete()
        {
            await _trHouseService.RemoveAllTradingHouses();
        }


        // GET: api/TradingHouseAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            TradingHouseDTO tr = await _trHouseService.GetTradingHouseByIdAsync(id);
            return Ok(tr);
        }

    }
}