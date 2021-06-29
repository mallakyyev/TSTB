using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Partners
{
    public class PartnerTranslate
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public Partners Partners { get; set; }
    }
}
