using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.DTOs.BillingModelDTO
{
    public class EditDeclatarionAccountant
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateCreateDeclaration { get; set; }
        
        [Required]
        public StatusDeclaration StatusDeclaration { get; set; }

        public string Description { get; set; }

        [Required]
        public int YearDeclaration { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public int? PaymentId { get; set; }
        
        [Required]
        public double Amount { get; set; }
    }
}
