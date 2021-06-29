using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Language
{
    public class Language
    {
        public string Culture { get; set; }

        public string Name { get; set; }

        public bool IsPublish { get; set; }

        public string FlagImage { get; set; }
        public int DisplayOrder { get; set; }
    }
}
