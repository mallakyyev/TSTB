using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.NativeProductionsDTO;
using TSTB.BLL.Services.NativeProductionService;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class NativeProductionAPIController : ControllerBase
    {

        private readonly INativeProductionService _nativeProduction;
        public NativeProductionAPIController(INativeProductionService nativeProduction)
        {
            _nativeProduction = nativeProduction;
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load<NativeProdutionDTO>(_nativeProduction.GetAllNativeProductions().AsQueryable(), loadOptions);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(int id)
        {
            await _nativeProduction.DeleteNativeProductionById(id);
        }
    }
}