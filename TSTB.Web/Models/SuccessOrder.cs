using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSTB.Web.Models
{
    public class SuccessOrder
    {
        public int orderStatus {get ; set;}
        public int errorCode { get; set; }
        public string errorMessage { get; set; }
        public string orderNumber { get; set; }
        public double amount { get; set; }
        public int currency { get; set; }
        public string ip { get; set; }
    }
}
