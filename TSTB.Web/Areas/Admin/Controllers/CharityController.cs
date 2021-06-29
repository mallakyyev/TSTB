using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.CharityModelDTO;
using TSTB.BLL.Services.Charity;
using Microsoft.AspNetCore.Authorization;
namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CharityController : Controller
    {
        private readonly ICharityService _charityService;
       
        public CharityController(ICharityService charityService)
        {
            _charityService = charityService;           
        }
        // GET: Admin/Charity
        public IActionResult Index()
        {
            return View();
        }

        // GET:  Admin/Charity/Create
        [HttpGet]
        public IActionResult Create()
        {            
            return View();
        }

        // Post:  Admin/Charity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCharityDTO ch)
        {
            if (ModelState.IsValid)
            {
                await _charityService.CreateCharity(ch);
                return RedirectToAction("Index");
            }           
            return View(ch);
        }

        [HttpGet]
        // GET:  Admin/Charity/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dept = await _charityService.GetCharityForEditById(id);

            if (dept == null)
            {
                return NotFound();
            }           
            return View(dept);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCharityDTO ch)
        {
            if (ModelState.IsValid)
            {
                await _charityService.EditCharity(ch);
                return RedirectToAction("Index");
            }            
            return View(ch);
        }     
    }
}