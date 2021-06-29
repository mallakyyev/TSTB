using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.NewsModelDTO;
using TSTB.BLL.Services.Charity;
using TSTB.BLL.Services.Industry;
using TSTB.BLL.Services.News;
using TSTB.BLL.Services.NewsPaper;
using TSTB.BLL.Services.Services;
using TSTB.BLL.ViewModel;
using TSTB.DAL.Models.News;

namespace TSTB.BLL.Services.SearchService
{
    public class SearchService : ISearchService
    {
        private readonly INewsService _newsService;
        private readonly INewsPaperService _newsPaperService;
        private readonly IServiceService _serviceService;
        private readonly IServicesTypeService _serviceTypeService;
        private readonly IIndustryService _industryService;
        public SearchService(INewsService newsService, INewsPaperService newsPaperService, IServiceService serviceService, 
                            IServicesTypeService servicesTypeService, IIndustryService industryService)
        {
            _newsService = newsService;
            _newsPaperService = newsPaperService;
            _serviceService = serviceService;
            _serviceTypeService = servicesTypeService;
            _industryService = industryService;
        }
        public List<SearchResultModel> Search(string text)
        {
            IEnumerable<SearchResultModel> resFromNews =  _newsService.SearchByNameAndDesc(text);
            IEnumerable<SearchResultModel> resFromNewsPaper = _newsPaperService.SearchByNameAndDesc(text);
            IEnumerable<SearchResultModel> resFromService = _serviceService.SearchByNameAndDesc(text);
            IEnumerable<SearchResultModel> resFromServiceType = _serviceTypeService.SearchByNameAndDesc(text);
            IEnumerable<SearchResultModel> resFromIndustry = _industryService.SearchByNameAndDesc(text);

            List<SearchResultModel> result = new List<SearchResultModel>(resFromNews);

            result.AddRange(new List<SearchResultModel>(resFromNewsPaper));
            result.AddRange(new List<SearchResultModel>(resFromService));
            result.AddRange(new List<SearchResultModel>(resFromServiceType));
            result.AddRange(new List<SearchResultModel>(resFromIndustry));
            List<SearchResultModel> sortedResult = result.OrderBy(o => o.Count).ToList();
            return sortedResult;
        }
    }
}
