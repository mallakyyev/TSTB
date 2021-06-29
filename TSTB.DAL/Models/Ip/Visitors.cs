using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Ip
{
    public class Visitors
    {
        public int Id { get; set; }
        public string  Ip { get; set; }
        public DateTime VisitDate { get; set; }
        
        public string Country { get; set; }
    }
}
