using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Partners
{
    public class  PartnersDataTranslate
    {
        public int Id { get; set; }
        public int PartnersDataId { get; set; }
        public string Description { get; set; }
        public string LanguageCulture { get; set; } 
        public PartnersData PartnersData { get; set; }
    }
}
