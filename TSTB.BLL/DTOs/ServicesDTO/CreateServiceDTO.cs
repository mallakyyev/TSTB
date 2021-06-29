using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.ServicesDTO
{
    public class CreateServiceDTO
    {
        public ICollection<ServiceTranslateDTO> ServiceTranslates { get; set; }
        
        [Required]
        public IFormFile SVG { get; set; }

        public string VideoLink { get; set; }

        [Required]
        public bool IsPublish { get; set; }
    }
}
