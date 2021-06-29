using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TSTB.Web.Controllers
{
    public class PressReleasesController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
