using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.DTOs.AdvertisementDTO
{
    public class CreateAdvertisementDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public BannerPosition Position { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public IFormFile FormFileBig { get; set; }

        [Required]
        public IFormFile FormFileSmall { get; set; }
        
        public string Link { get; set; }
        
        public int Order { get; set; }

        [Required]
        public bool IsPublish { get; set; }
    }
}
