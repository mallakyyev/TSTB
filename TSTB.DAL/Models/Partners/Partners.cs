using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Partners
{
    public class Partners
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Logo { get; set; }
        public bool IsPublish { get; set; }
        public PartnersData PartnersData { get; set; }
        public ICollection<PartnerTranslate> PartnerTranslates { get; set; }
    }
}
