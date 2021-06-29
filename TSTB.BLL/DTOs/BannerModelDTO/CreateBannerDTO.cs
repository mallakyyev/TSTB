using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.DTOs.BannerModelDTO
{
    public class CreateBannerDTO
    {
        [Required]
        public ICollection<BannerTranslateDTO> BannerTranslate { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public BannerPosition BannerPosition { get; set; }

        public bool IsPublish { get; set; }
        
        public string Link { get; set; }
      

    }
}
