using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Enums;
using TSTB.DAL.Models.User;

namespace TSTB.DAL.Models.Billing
{
    public class Payment
    {
        public int Id { get; set; }
        public int?  CurrencyCode { get; set; }
        public string  Language { get; set; }
        public string PageView { get; set; }
        public string  Description { get; set; }
        public string OrderNumber { get; set; }
        public string BankOrderId { get; set; }
        public double Amount { get; set; }
        public StatusPayment?  StatusPayment { get; set; }
        public DateTime? DatePayment{ get; set; }
        public DateTime PaymentCreatedDate { get; set; }
        public int? DeclarationId { get; set; }
        public Declaration  Declaration{ get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser{ get; set; }

    }
}
