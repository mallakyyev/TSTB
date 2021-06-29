using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TSTB.Web.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        //private readonly RoleManager<IdentityRole> _roleManager;

      
        [Area("Admin")]
        [Authorize(Roles = "Admin, Content-Manager, Registration-Manager")]
        public  IActionResult Index()
        {           
            return View();
        }



    }
}