using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSTB.BLL.ViewModel;

namespace TSTB.BLL.Services.SearchService
{
    public interface ISearchService
    {
        public List<SearchResultModel> Search(string text);
    }
}
