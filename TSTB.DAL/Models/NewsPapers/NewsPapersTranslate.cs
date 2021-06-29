using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.NewsPapers
{
    public class NewsPapersTranslate
    {
        public int Id { get; set; }
        public int NewsPaperId { get; set; }
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public NewsPaper NewsPaper { get; set; }
    }
}
