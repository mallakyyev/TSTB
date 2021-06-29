using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Services
{
    public class ServiceTranslate
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LanguageCulture { get; set; }
        public Services Services { get; set; }
    }
}
