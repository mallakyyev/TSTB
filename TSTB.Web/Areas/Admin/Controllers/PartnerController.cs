using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.PartnersModelDTO;
using TSTB.BLL.Services.Language;
using TSTB.BLL.Services.Partner;
using TSTB.Web.Areas.Admin.Models;

namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class PartnerController : Controller
    {
        private readonly IPartnerService _partnerService;
        private readonly IPartnerDataService _partnerDataService;
        private readonly ILanguageService _languageService;

        public PartnerController(IPartnerService partnerService, IPartnerDataService partnerDataService, ILanguageService langService)
        {
            _partnerService = partnerService;
            _partnerDataService = partnerDataService;
            _languageService = langService;
        }
        // GET: Admin/Partner
        public IActionResult Index()
        {
            return View();
        }


        // GET: Admin/Partner/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        // Post: Admin/Partner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePartnerAndDataModel pd)
        {
            if (ModelState.IsValid)
            {
                var partner = await _partnerService.CreatePartner(pd.CreatePartnerDTO);
                pd.CreatePartnerDataDTO.PartnerId = partner;
                await _partnerDataService.CreatePartnerData(pd.CreatePartnerDataDTO);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(pd);
        }

        [HttpGet]
        // GET: Admin/Partner/Edit/5
        public async Task<IActionResult> Edit(int id)
        { 

            EditPartnerAndDataModel pd = new EditPartnerAndDataModel
            {
                EditPartnerDTO = await _partnerService.GetPartnerForEditById(id),
                EditPartnerDataDTO = await _partnerDataService.GetPartnerDataForEditById(id)
            };
            //var partner = await _partnerService.GetPartnerForEditById(id);

            if (pd.EditPartnerDTO == null && pd.EditPartnerDataDTO == null)
            {
                return NotFound();

            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(pd);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditPartnerAndDataModel pr)
        {
            if (ModelState.IsValid)
            {
                await _partnerService.EditPartner(pr.EditPartnerDTO);
                await _partnerDataService.EditPartnerData(pr.EditPartnerDataDTO);
                //System.IO.File.WriteAllLines(@"D:\Image.txt", pr.EditPartnerDataDTO.ImageName);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);

            return View(pr);
        }

        // GET: Admin/Partner/Delete/5
        public IActionResult Delete(int? id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

    }
}