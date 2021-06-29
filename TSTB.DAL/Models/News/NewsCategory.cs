using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.News
{
    public class NewsCategory
    {
        public int Id { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<NewsCategoryTranslate> NewsCategoryTranslates { get; set; }
    }
}
