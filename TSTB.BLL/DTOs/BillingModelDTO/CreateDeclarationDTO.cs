using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.DTOs.BillingModelDTO
{
    public class CreateDeclarationDTO
    {      
       
        [Required]
        public int YearDeclaration { get; set; }

        [Required]
        public IEnumerable<IFormFile> FormFiles { get; set; }

    }
}
