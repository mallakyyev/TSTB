using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.NewsPaperModelDTO;
using TSTB.BLL.Services.NewsPaper;
using TSTB.DAL.Models.NewsPapers;

namespace TSTB.Web.Controllers
{
    public class NewsPaperController : Controller
    {
        private readonly INewsPaperService _newsPaperDataService;
        public NewsPaperController(INewsPaperService newsPaperService)
        {
            _newsPaperDataService = newsPaperService;
        }
        public IActionResult Index()
        {
            var newsPapers = _newsPaperDataService.GetAllPublishNewsPaperData();
            return View(newsPapers);
        }
        public IActionResult List(int id)
        {
            List<NewsPaperDataDTO> r = new List<NewsPaperDataDTO>(_newsPaperDataService.GetNewsPaperDataByNewsPaperId(id));
            return View(r);
        }

        public IActionResult NewsPaperDetails(int id) {
            ViewBag.Culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            NewsPaperData d = _newsPaperDataService.GetNewsPaperDataAndFiles(id);
            return View(d);
        }

    }
}