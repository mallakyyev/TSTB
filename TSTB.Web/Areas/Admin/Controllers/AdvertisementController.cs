using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.AdvertisementDTO;
using TSTB.BLL.Services.AdvertisementService;

namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementService _advertisementService;
        public AdvertisementController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAdvertisementDTO adv)
        {
            if (ModelState.IsValid)
            {
                await _advertisementService.CreateAdvertisement(adv);
                return RedirectToAction("Index");
            }
           
            return View(adv);
        }

        [HttpGet]        
        public async Task<IActionResult> Edit(int id)
        {
            var adv = await _advertisementService.GetAdvertisementForEditById(id);
            if (adv == null)
            {
                return NotFound();
            }
           
            return View(adv);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditAdvertisementDTO adv)
        {
            if (ModelState.IsValid)
            {
                await _advertisementService.EditAdvertisement(adv);
                return RedirectToAction("Index");
            }
           
            return View(adv);
        }
    }
}