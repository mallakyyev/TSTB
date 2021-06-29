using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSTB.BLL.DTOs.NewsModelDTO;
using TSTB.BLL.Services.News;
using TSTB.BLL.Services.NewsCategory;
using TSTB.Web.Extensions;

namespace TSTB.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly INewsCategoryService _newsCategoryService;
        private static List<NewsDTO> All;
        private static List<NewsDTO> allPublishNews;
        public NewsController(INewsService newsService, INewsCategoryService newsCategoryService)
        {
            All = new List<NewsDTO>();
            _newsService = newsService;
            _newsCategoryService = newsCategoryService;
            allPublishNews = new List<NewsDTO>(_newsService.GetAllPublishNews());
            All = allPublishNews.OrderByDescending(o => o.Id).ToList();
        }

        public IActionResult Index(int catId, string filterDate)
        {
            DateTime filter = new DateTime();
            if (filterDate != null)
                filter = DateTime.Parse(filterDate);
            DateTime k = new DateTime();
            ViewBag.NewsCategories = _newsCategoryService.GetAllNewsCategory();
            ViewBag.CatId = catId;
            ViewBag.DateFilter = filter;
          //  List<NewsDTO> AllbyCat;
            if (catId > 0)
            {
                if (filter > k)
                {
                    All = new List<NewsDTO>(_newsService.GetNewsByDateAndCategory(filter, catId)).OrderByDescending(p => p.DatePublished).ToList();                    
                }
                else
                {
                    All = new List<NewsDTO>(_newsService.GetNewsByCategory(catId)).OrderByDescending(p => p.DatePublished).ToList();                  
                }  

                if (All.Count < 12)
                        return View(All);
                    else
                        return View(new List<NewsDTO>(All.Take(12)));
            } 
            else if(filter > k)
            {
                All = new List<NewsDTO>(_newsService.GetNewsByDate(filter));
                if (All.Count < 12)
                    return View(All);
                else
                    return View(new List<NewsDTO>(All.Take(12)));
            }

            if (All.Count < 12)
                return View(All);
            else
                return View(new List<NewsDTO>(All.Take(12)));
          
        }

        public JsonResult GetData(int pageSize, int pageCount,int catId, string filterDate)
        {
            DateTime filter = new DateTime();
            if (filterDate != null)
                filter = DateTime.Parse(filterDate.Substring(0,8));
           
            ViewBag.NewsCategories = _newsCategoryService.GetAllNewsCategory();
            ViewBag.CatId = catId;
            ViewBag.DateFilter = filter;
            //  List<NewsDTO> AllbyCat;
            if (catId > 0)
            {
                if (filter.Year > 2001)
                {
                    All = new List<NewsDTO>(_newsService.GetNewsByDateAndCategory(filter, catId)).OrderByDescending(p => p.DatePublished).ToList();
                }
                else
                {
                    All = new List<NewsDTO>(_newsService.GetNewsByCategory(catId)).OrderByDescending(p => p.DatePublished).ToList();
                }              
            }
            else if (filter.Year > 2001)
            {
                All = new List<NewsDTO>(_newsService.GetNewsByDate(filter));              
            }

            List<NewsDTO> list = new List<NewsDTO>();

            if(All.Count() > pageSize)
            {
                for(int i = pageSize; i < All.Count(); ++i)
                {                    
                    list.Add(All.ToArray()[i]);
                    if (i >= (pageSize-1 + pageCount * 8))
                        break;
                }
            }
           
            
                foreach (NewsDTO l in list)
                {
                    l.ShortDate = l.DatePublished.ToDateFormat();
                }
                JsonResult r = Json(list);
                r.SerializerSettings = new System.Text.Json.JsonSerializerOptions();
                return r;        
            
        }
        public async Task<IActionResult> Details(int id)
        {
            NewsDTO d = await _newsService.GetNewsByIdAsync(id);
            return View(d);
        }
        
    }
}