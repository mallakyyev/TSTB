using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Representatives
{
    public class RepresentativesTranslate
    {
        public int Id { get; set; }
        public int RepresentativeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LanguageCulture { get; set; }
        public Representatives Representatives { get; set; }
    }
}
