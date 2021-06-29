using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.Services.Departments;

namespace TSTB.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentsService _departmentsService;

        public DepartmentController(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        public IActionResult Index(int? id = null)
        {
            var departments = _departmentsService.GetAllPublishDepartments().OrderBy(o => o.Id);
            ViewBag.Department = id != null ? departments.SingleOrDefault(s => s.Id == id) : departments.FirstOrDefault();           

            return View(departments);
        }
    }
}
