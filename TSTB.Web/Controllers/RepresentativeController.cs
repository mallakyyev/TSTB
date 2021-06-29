using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.Services.Representative;

namespace TSTB.Web.Controllers
{
    public class RepresentativeController : Controller
    {
        private readonly IRepresentativeService _representativeService;

        public RepresentativeController(IRepresentativeService representativeService)
        {
            _representativeService = representativeService;
        }

        public IActionResult Index()
        {
            var representatives = _representativeService.GetAllPublishRepresentatives();

            return View(representatives);
        }
    }
}
