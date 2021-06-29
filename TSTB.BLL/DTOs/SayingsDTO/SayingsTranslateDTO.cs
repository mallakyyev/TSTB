using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.SayingsDTO
{
    public class SayingsTranslateDTO
    {
        public int Id { get; set; }

        [Required]
        public int SayingsId { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string AuthorPosition { get; set; }

        [Required]
        public string SayingsText { get; set; }

        [Required]
        public string LanguageCulture { get; set; }
    }
}
