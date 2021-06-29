using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Representatives
{
    public class Representatives
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Person { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Site { get; set; }
        public string Email { get; set; }
        public bool IsPublish { get; set; }
        public ICollection<RepresentativesTranslate> RepresentativesTranslates { set; get; }
    }
}
