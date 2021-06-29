using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.DTOs.CharityModelDTO
{
    public class EditPaymentCharityDTO
    {
        public int Id { get; set; }

        [Required]
        public int CharityId { get; set; }

        [Required]
        public string ApplicationtUserId { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        public string Description { get; set; }
        [Required]
        public StatusPayment PaymentStatus { get; set; }

        public string BankPaymentId { get; set; }

        [Required]
        public string PaymentNumber { get; set; }
    }
}
