using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.BillingModelDTO;
using TSTB.BLL.Services.Employee;
using TSTB.DAL.Models.User;

namespace TSTB.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class AccountantController : Controller
    {
        private readonly IEmployeeService _empService;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountantController(IEmployeeService employeeService, UserManager<ApplicationUser> userManager)
        {
            _empService = employeeService;
            _userManager = userManager;
        }
        // GET: Admin/Accountant
        public IActionResult Index()
        {
            return View();
        }


        // GET: Employee/Accountant/Create
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        // GET: Employee/Accountant/Tariff
        [HttpGet]
        public IActionResult Tariff()
        {

            return View();
        }
        public IActionResult Transactions()
        {

            return View();
        }

        //// Post: Employee/Accountant/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(CreateDeclarationDTO CreateDecDTO)
        //{

        //}

        [HttpGet]
        // GET: Employee/Declaration/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dec = await _empService.GetDeclarationForEditById(id);
            if (dec == null)
            {
                return NotFound();
            }
            return View(dec);
        }

        // Post: Employee/Declaration/Edit/
        [HttpPost]
        public async Task<IActionResult> Edit(EditDeclarationDTO ed)
        {
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

        public IActionResult List()
        {
            return View();
        }

    }
}