using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.NewsPapers
{
    public class NewsPaperData
    {
        public int Id { get; set; }
        public int NewsPaperId { get; set; }
        public string Image { get; set; }
        public DateTime DataOfPublish { get; set; }
        
        public NewsPaper NewsPaper { get; set; }
        public ICollection<NewsPaperFiles> NewsPaperFiles { get; set; }
        public bool IsPublish { get; set; }
    }
}
