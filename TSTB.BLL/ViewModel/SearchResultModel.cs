using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.ViewModel
{
    public class SearchResultModel
    {
        public string Id { get; set; }
        public int SearchResultId { get; set; }
        public string SearchResultTextinTitle { get; set; }
        public string  SearchResultTextinDescription{ get; set; }
        public SearchResultType ResultType { get; set; }
        public int Count { get; set; }

    }
}
