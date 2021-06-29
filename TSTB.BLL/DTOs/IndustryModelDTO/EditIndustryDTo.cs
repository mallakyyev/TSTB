using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.IndustryModelDTO
{
    public class EditIndustryDTO
    {
        public int Id { get; set; }

        public ICollection<IndustryTranslateDTO> IndustryTranslates { get; set; }

        [Required]
        public bool IsPublish { get; set; }

        public IFormFile SVG { get; set; }

        public string LogoName { get; set; }
    }
}
