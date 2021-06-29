using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Charity
{
    public class Charity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string  Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<PaymentCharity> PaymentCharity { get; set; }
        public bool IsPublish { get; set; }
    }
}
