using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.OnlineTradeDTO;
using TSTB.BLL.Services.Language;
using TSTB.BLL.Services.OnlineTrading;

namespace TSTB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Content-Manager")]
    public class OnlineTradingController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;
        private readonly IOnlineTradingService _onlineTRService;
        public OnlineTradingController(ILanguageService languageService, IMapper mapper, IOnlineTradingService onlineTradingService)
        {
            _languageService = languageService;
            _mapper = mapper;
            _onlineTRService = onlineTradingService;
        }
        public IActionResult Index()
        {
            return View();
        }
                                                // Online Trading Activity Type Control
        public IActionResult Activities()
        {

            return View();
        }


        [HttpGet]
        public IActionResult CreateActivity()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(CreateOnlineTradingActivityTypeDTO createModel)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            if (ModelState.IsValid)
            {
                await _onlineTRService.CreateOnlineTradingActivityType(createModel);
                return RedirectToAction("Activities");
            }
            else
            {
                return View(createModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditActivity(int id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            var result = await _onlineTRService.GetOnlineTradingActivityTypeForEditById(id);
            if (result == null)
                return NotFound();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> EditActivity(EditOnlineTradingActivityTypeDTO modelDTO)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            if (ModelState.IsValid)
            {
                await _onlineTRService.EditOnlineTradingActivityType(modelDTO);
                return RedirectToAction("Activities");
            }
            else
            {
                return View(modelDTO);
            }
        }

                                            // Online Trading Category Control
        public IActionResult Categories()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateOnlineTradingCategoryDTO createModel)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            if (ModelState.IsValid)
            {
                await _onlineTRService.CreateOnlineTradingCategory(createModel);
                return RedirectToAction("Categories");
            }
            else
            {
                return View(createModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            var result = await _onlineTRService.GetOnlineTradingCategoryForEditById(id);
            if (result == null)
                return NotFound();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(EditOnlineTradingCategoryDTO modelDTO)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            if (ModelState.IsValid)
            {
                await _onlineTRService.EditOnlineTradingCategory(modelDTO);
                return RedirectToAction("Categories");
            }else
            {
                return View(modelDTO);
            }
        }

        //////////////////////////////////Online Trading/////////////////////////////////
        [HttpGet]
        public IActionResult CreateOnlineTrading()
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            CreateOnlineTradingDTO s = new CreateOnlineTradingDTO();
            s.PhoneNumbers = new List<string>(10);            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOnlineTrading(CreateOnlineTradingDTO modelDTO)
        {
            if (ModelState.IsValid)
            {
                await _onlineTRService.CreateOnlineTrading(modelDTO);
                return RedirectToAction("Index");
            }
            return View(modelDTO);
            
        }

        [HttpGet]
        public async Task<IActionResult> EditOnlineTrading(int id)
        {
            ViewBag.Languages = _languageService.GetAllPublishLanguage().OrderBy(o => o.DisplayOrder);
            EditOnlineTradingDTO r = await _onlineTRService.GetOnlineTradingForEditById(id);
            return View(r);
        }

        [HttpPost]
        public async Task<IActionResult> EditOnlineTrading(EditOnlineTradingDTO modelDTO)
        {
            if (ModelState.IsValid)
            {
                await _onlineTRService.EditOnlineTrading(modelDTO);
                return  RedirectToAction("Index");
            }
            return View(modelDTO);
        }
    }
}