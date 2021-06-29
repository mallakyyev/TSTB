using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.Services.Partner;

namespace TSTB.Web.Controllers
{
    public class PartnerController : Controller
    {
        private readonly IPartnerService _partnerService;
        private readonly IPartnerDataService _partnerDataService;

        public PartnerController(IPartnerService partnerService, IPartnerDataService partnerDataService)
        {
            _partnerService = partnerService;
            _partnerDataService = partnerDataService;
        }

        public IActionResult Index()
        {
            var partners = _partnerService.GetAllPublishPartners();
            return View(partners);
        }

        public async Task<IActionResult> Detail(int id)
        {
            ViewBag.Partner = await _partnerService.GetPublishPartnerByIdAsync(id);
            var partnerData = await _partnerDataService.GetPartnerDataDTOByPartnerId(id);
            return View(partnerData);
        }
    }
}
