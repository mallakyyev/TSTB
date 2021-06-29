using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TSTB.BLL.DTOs.BillingModelDTO;
using TSTB.BLL.Services.Employee;
using TSTB.DAL.Models.User;
using TSTB.Web.Areas.Identity.Pages.Account;

namespace TSTB.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class DeclarationController : Controller
    {
        private readonly IEmployeeService _empService;
        private readonly UserManager<ApplicationUser> _userManager;
        public DeclarationController(IEmployeeService employeeService, UserManager<ApplicationUser> userManager)
        {
            _empService = employeeService;
            _userManager = userManager;
        }
        // GET: Admin/Declaration
        public IActionResult Index()
        {
            return View();
        }


        // GET: Employee/Declaration/Create
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        // Post: Employee/Declaration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDeclarationDTO CreateDecDTO)
        {
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                List<string> err = new List<string>
                {
                    "User does not exists or session timed out!!!"
                };
                ViewBag.ErrorList = err;
                return View(CreateDecDTO);
            }
            string id = user.Id;    
           
            if (ModelState.IsValid)
            {
                await _empService.CreateDeclaration(CreateDecDTO,id);
                return RedirectToAction("Index");
            }
           
            return View(CreateDecDTO);
        }

        [HttpGet]
        // GET: Employee/Declaration/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dec = await _empService.GetDeclarationForEditById(id);
            if(dec.StatusDeclaration != DAL.Models.Enums.StatusDeclaration.Cancelled)
                return RedirectToAction("Index");
            if (dec == null)
            {
                    return NotFound();
            }
            if (dec.StatusDeclaration != DAL.Models.Enums.StatusDeclaration.Cancelled)
            {
                return RedirectToAction("Index");
            }
            return View(dec);
        }

        // Post: Employee/Declaration/Edit/
        [HttpPost]
        public async Task<IActionResult> Edit(EditDeclarationDTO ed)
        {           
            if (ed.OldYear != ed.YearDeclaration || ed.FormFiles != null)
                ed.StatusDeclaration = DAL.Models.Enums.StatusDeclaration.Pending;
            if (ModelState.IsValid)
            {
                await _empService.EditDeclaration(ed);
                return RedirectToAction("Index");
            }
            

            return View(ed);
        }

        // GET: Employee/Declaration/Delete/5
        public IActionResult Delete(int? id)
        {
            
            return View();
        }
    }
}