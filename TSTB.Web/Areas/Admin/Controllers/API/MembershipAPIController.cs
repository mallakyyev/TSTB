using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.Services.MembershipRequest;
using TSTB.DAL.Models.MembershipRequest;
using TSTB.Web.Binder;

namespace TSTB.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipAPIController : ControllerBase
    {
        private readonly IMembershipRequestService _requestService;
        public MembershipAPIController(IMembershipRequestService requestService)
        {
            _requestService = requestService;
        }
        // GET: api/MembershipRequestAPI
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_requestService.GetAllMembershipRequests().AsQueryable(), loadOptions);
        }

        [HttpDelete("{id}")]        
        public async Task DeleteAsync(int id)
        {
            await _requestService.DeleteMembershipRequestById(id);
        }

    }
}