using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Services
{
    /// <summary>
    /// Услуги
    /// </summary>
    public class Services
    {
        public int Id { get; set; }

        public bool IsPublish { get; set; }
        public string Logo { get; set; }
        public string VideoLink { get; set; }
        public ICollection<ServiceType> ServiceTypes { get; set; }
        public ICollection<ServiceTranslate> ServiceTranslates { get; set; }
    }
}
