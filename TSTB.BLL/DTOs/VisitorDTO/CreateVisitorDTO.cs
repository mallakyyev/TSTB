using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.BLL.DTOs.VisitorDTO
{
    public class CreateVisitorDTO
    {
        public string Ip { get; set; }
        public DateTime VisitDate { get; set; }
      
        public string Country { get; set; }
    }
}
