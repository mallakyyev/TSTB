using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.CallBackModelDTO;
using TSTB.BLL.Services.CallBacks;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallBacksAPIController : ControllerBase
    {
        private readonly ICallBackService _callBackService;
        private readonly ICityService _cityService;
        public CallBacksAPIController(ICallBackService callBack, ICityService cityService)
        {
            _callBackService = callBack;
            _cityService = cityService;
        }

        // GET: api/CallBacksAPI
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<CallBackDTO>(_callBackService.GetAllCallBacks().AsQueryable(), loadOptions);
        }

        // GET: api/CallBacksAPI/GetAllCities
        [HttpGet("GetAllCities")]
        public object GetAllCities(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<CitiesDTO>(_cityService.GetAllCities().AsQueryable(), loadOptions);
        }

        // GET: api/CallBacksAPI/GetAllCities/{id}
        [HttpDelete("GetAllCities/{id}")]
        public async Task GetAllCities(int id)
        {
            await _cityService.RemoveCity(id);
        }

        // GET: api/CallBacksAPI/GetAllPublishCallBakcs
        [HttpGet("GetAllPublishCallBakcs")]
        public object GetAllPublishCallBakcs(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<CallBackDTO>(_callBackService.GetAllPublishcallBacks().AsQueryable(), loadOptions);
        }


        // POST: api/CallBacksAPI
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateCallBackDTO value)
        {
            if (ModelState.IsValid)
            {
                await _callBackService.CreateCallBack(value);
                return Ok(value);
            }
            return BadRequest();
        }

        // PUT: api/CallBacksAPI/5
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Put([FromForm] EditCallBackDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _callBackService.EditCallBack(value);
            return Ok(value);
        }


        // GET: api/CallBacksAPI/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            CallBackDTO callBack = await _callBackService.getCallBackById(id);
            return Ok(callBack);
        }

        // DELETE: api/CallBacksAPI/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _callBackService.RemoveCallBack(id);
        }

        // DELETE: api/CallBacksAPI
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task Delete()
        {
            await _callBackService.RemoveAllCallBacks();
        }
        

    }
}