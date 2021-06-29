using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.NewsPapers
{
    public class NewsPaperFiles
    {
        public int Id { get; set; }
        public int NewsPaperDataId { get; set; }
        public string Image { get; set; }
        public NewsPaperData NewsPaperData { get; set; }
    }
}
