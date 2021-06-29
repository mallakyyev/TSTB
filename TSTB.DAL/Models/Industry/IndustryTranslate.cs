using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Industry
{
    public class IndustryTranslate
    {
        public int Id { get; set; }
        public int IndustryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LanguageCulture { get; set; }
        public Industry Industry { get; set; }

    }
}
