using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.IndustryModelDTO
{
    public class CreateIndustryDTO
    {
        public ICollection<IndustryTranslateDTO> IndustryTranslates { get; set; }

        [Required]
        public bool IsPublish { get; set; }

        [Required]
        public  IFormFile SVG  { get; set; }
    }
}
