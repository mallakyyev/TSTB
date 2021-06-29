using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.Services.SearchService;
using TSTB.Web.Models;

namespace TSTB.Web.Controllers
{   
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        public IActionResult Search(string text)
        {
            if (text != null)
            {
                var result =  _searchService.Search(text);
                //ViewBag.Result = result;
                return View(result);
            }
            return View();            
        }
    }
}