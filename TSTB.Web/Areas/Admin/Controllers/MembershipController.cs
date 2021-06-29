using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.MembershipRequestDTO;
using TSTB.BLL.Services.MembershipRequest;
using TSTB.DAL.Models.MembershipRequest;
using TSTB.Web.Data;

namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Registration-Manager")]
    public class MembershipController : Controller
    {
        private readonly IMembershipRequestService _requestService;
        private readonly ApplicationDbContext _applicationDbContext;
        public MembershipController(IMembershipRequestService requestService, ApplicationDbContext application)
        {
            _requestService = requestService;
            _applicationDbContext = application;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _requestService.GetMembershipRequestById(id));
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MembershipRequest model)
        {
            _applicationDbContext.MembershipRequests.Update(model);
            await _applicationDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}