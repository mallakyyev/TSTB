using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSTB.Web.Areas.Employee.Models
{
    public class CharityDetailsModel
    {
        public int Id { get; set; }
        public double  Amount{ get; set; }
        public DateTime PaymentDate { get; set; }
        public string  Comment { get; set; }
    }
}
