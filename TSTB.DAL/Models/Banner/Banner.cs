using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.DAL.Models.Banner
{
    public class Banner
    {
        public int Id { get; set; }
        public BannerPosition BannerPosition { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate{ get; set; }
        
        public bool IsPublish { get; set; }
        public string  Link { get; set; }
        public ICollection<BannerTranslate> BannerTranslate { get; set; }
    }
}
