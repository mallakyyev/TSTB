using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Services
{
    public class ServiceTypeTranslate
    {
        public int Id { get; set; }
        public int ServiceTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LanguageCulture { get; set; }
        public ServiceType ServiceType { get; set; }

    }
}
