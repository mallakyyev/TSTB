using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Services
{
    public class ServiceType
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public bool IsPublish { get; set; } 
        public Services Services { get; set; }
        public ICollection<ServiceTypeTranslate> ServiceTypeTranslates { set; get; }
    }
}
