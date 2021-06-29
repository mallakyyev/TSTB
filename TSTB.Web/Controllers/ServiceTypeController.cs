using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.ServicesDTO;
using TSTB.BLL.Services.Services;

namespace TSTB.Web.Controllers
{
    public class ServiceTypeController : Controller
    {
        private readonly IServicesTypeService _serviceTypeService;
        public ServiceTypeController(IServicesTypeService servicesTypeService)
        {
            _serviceTypeService = servicesTypeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            ServiceTypeDTO d = await _serviceTypeService.GetServiceTypeById(id);
            return View(d);
        }
    }
}