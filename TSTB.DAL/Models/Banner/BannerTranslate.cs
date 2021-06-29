using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Banner
{
    public class BannerTranslate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public int BannerId { get; set; }
        public string LanguageCulture { get; set; }
        public string Image { get; set; }
        public Banner Banner { get; set; }
    }
}
