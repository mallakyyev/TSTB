using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Enums;
using TSTB.DAL.Models.User;

namespace TSTB.DAL.Models.Charity
{
    public class PaymentCharity
    {
        public int Id { get; set; }
        public int CharityId { get; set; }
        public string ApplicationtUserId { get; set; }
        public double  Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Description { get; set; }
        public StatusPayment PaymentStatus { get; set; }
        public Charity Charity { get; set; }
        public ApplicationUser ApplicationUser{ get; set; }
        public string BankPaymentId { get; set; }
        public string PaymentNumber { get; set; }
    }
}
