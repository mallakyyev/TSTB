using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.CharityModelDTO
{
    public class CreateCharityDTO
    {        

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Picture { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool IsPublish { get; set; }
        
        public IFormFile FormFile { get; set; }
    }
}
