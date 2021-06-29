using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSTB.Web.Models
{
    public class ResponseRegistrationOrder
    {
        public string orderId { get; set; }
        public string formUrl { get; set; }
        public int errorCode { get; set; }
        public string errorMessage { get; set; }
    }
}
