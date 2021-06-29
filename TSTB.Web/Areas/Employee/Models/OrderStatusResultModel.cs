using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSTB.Web.Areas.Employee.Models
{
    public class OrderStatusResultModel
    {
        public int orderStatus { get; set; }
        public int errorCode { get; set; }
        public string errorMessage { get; set; }
        public string orderNumber { get; set; }
        public int amount { get; set; }
        public int currency { get; set; }
        public string ip { get; set; }
    }
}
