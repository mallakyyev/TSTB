using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.MembershipRequestDTO;
using TSTB.BLL.Services.MembershipRequest;

namespace TSTB.Web.Controllers
{
    public class MembershipRequestController : Controller
    {
        private readonly IMembershipRequestService _requestService;

        public MembershipRequestController(IMembershipRequestService requestService)
        {
            _requestService = requestService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }        

        [HttpGet]
        public IActionResult CreateEntreprenuer()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateLegalPerson()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateEntreprenuer(CreateMembershipRequestForEntreprenuerDTO model)
        {
            if (ModelState.IsValid)
            {
                await _requestService.CreateMembershipRequestForEntreprenuer(model);
                return RedirectToAction("Success");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLegalPerson(CreateMembrshipRequestForLegalPersonDTO model)
        {
            if (ModelState.IsValid)
            {
                await _requestService.CreateMembershipRequestForLegalPerson(model);
                return RedirectToAction("Success");
            }
            return View(model);
        }
    }
}