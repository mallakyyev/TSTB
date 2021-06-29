using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.BannerModelDTO
{
    public class BannerTranslateDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        public int BannerId { get; set; }

        [Required]
        public string LanguageCulture { get; set; }

        public string Image { get; set; }
        
        
        public IFormFile FormFile { get; set; }

    }
}
