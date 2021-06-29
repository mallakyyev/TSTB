using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Industry
{
    public class Industry
    {
        public int Id { get; set; }
        public bool IsPublish { get; set; }
        public string Logo { get; set; }
        public ICollection<IndustryTranslate> IndustryTranslates { get; set; }
    }
}
