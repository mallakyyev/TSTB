using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.NewsPapers
{
    public class NewsPaper
    {
        public int Id { get; set; }
        public bool IsPublish { get; set; }
        public ICollection<NewsPapersTranslate> NewsPapersTranslates { get; set; }
        public ICollection<NewsPaperData> NewsPaperDatas { get; set; }
    }
}
