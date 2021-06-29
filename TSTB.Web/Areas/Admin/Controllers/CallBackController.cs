using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.CallBackModelDTO;
using TSTB.BLL.Services.CallBacks;
using TSTB.BLL.Services.Language;
using Microsoft.AspNetCore.Authorization;
namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class CallBackController : Controller
    {
        private readonly ICallBackService _callBackService;
        private readonly ICityService _cityService;
        private readonly ILanguageService _languageService;

        public CallBackController(ICallBackService callBackService, ICityService cityService, ILanguageService langService)
        {
            _callBackService = callBackService;
            _cityService = cityService;
            _languageService = langService;

        }
        // GET: Admin/CallBack
        public IActionResult Index()
        {
            return View();
        }


        // GET: Admin/CallBack/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        // Post: Admin/CallBack/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCallBackDTO cb)
        {
            if (ModelState.IsValid)
            {
                await _callBackService.CreateCallBack(cb);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(cb);
        }

        [HttpGet]
        // GET: Admin/CallBack/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dept = await _callBackService.GetCallBackForEditById(id);

            if (dept == null)
            {
                return NotFound();

            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View(dept);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditCallBackDTO pr)
        {
            if (ModelState.IsValid)
            {
                await _callBackService.EditCallBack(pr);
                return RedirectToAction("Index");
            }
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);

            return View(pr);
        }

        // GET: Admin/CallBack/Delete/5
        public IActionResult Delete(int? id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }
    }
}