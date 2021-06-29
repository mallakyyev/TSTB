using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.ServicesDTO
{
    public class EditServiceDTO
    {
        public int Id { get; set; }
        public string LogoName { get; set; }        
        public IFormFile SVG { get; set; }

        public string VideoLink { get; set; }
        public ICollection<ServiceTranslateDTO> ServiceTranslates { get; set; }

        [Required]
        public bool IsPublish { get; set; }
    }
}
