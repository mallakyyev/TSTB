using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TSTB.DAL.Models.Billing;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.DTOs.BillingModelDTO
{
    public class CreatePaymentDTO
    {
        public int? CurrencyCode { get; set; }
        public string Language { get; set; }
        public string PageView { get; set; }
        public string Description { get; set; }
        public string OrderNumber { get; set; }
        public string BankOrderId { get; set; }

        [Required]
        public double Amount { get; set; }
        public StatusPayment? StatusPayment { get; set; }
        public DateTime? DatePayment { get; set; }
        public DateTime PaymentCreatedDate { get; set; }
        public int? DeclarationId { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
    }
}
