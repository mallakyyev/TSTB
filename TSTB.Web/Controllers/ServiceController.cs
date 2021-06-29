using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.ServicesDTO;
using TSTB.BLL.Services.Services;

namespace TSTB.Web.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var serviceDTO = await _serviceService.GetServicebyId(id);
            return View(serviceDTO);
        }
    }
}