using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSTB.Web.Areas.Employee.Models
{
    public class CharityPaymentModel
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string  Description { get; set; }
        public string Image{ get; set; }
        public int CharityId { get; set; }
        public string ApplicationUserId { get; set; }
        public double Amount { get; set; }
        public string PaymentDescription { get; set; }
    }
}
