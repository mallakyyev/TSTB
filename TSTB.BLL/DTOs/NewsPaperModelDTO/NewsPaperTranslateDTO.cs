using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.NewsPaperModelDTO
{
    public class NewsPaperTranslateDTO
    {
        public int Id { get; set; }

        [Required]
        public int NewsPaperId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LanguageCulture { get; set; }
    }
}
