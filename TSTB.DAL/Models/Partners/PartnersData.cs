using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Partners
{
    public class PartnersData
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public string Image { get; set; }
        
        public Partners Partners { get; set; }
        public bool IsPublish { get; set; }
        public ICollection<PartnersDataTranslate> PartnersDataTranslates { get; set; }
        
    }
}
