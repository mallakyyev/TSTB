using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace TSTB.BLL.DTOs.PartnersModelDTO
{
    public class CreatePartnerDTO
    {
        public ICollection<PartnerTranslateDTO> PartnerTranslates { get; set; }
        
        [Required]
        public int Order { get; set; }

        [Required]
        public IFormFile FormFile { get; set; }

        public bool IsPublish { get; set; }
    }
}
