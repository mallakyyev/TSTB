using Microsoft.AspNetCore.Mvc;

namespace TSTB.Web.Areas.Admin.Controllers
{
    [Route("file-manager")]
    [Area("Admin")]
    public class FileManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}