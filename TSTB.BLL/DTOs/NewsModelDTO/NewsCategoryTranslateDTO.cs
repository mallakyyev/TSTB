using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.NewsModelDTO
{
    public class NewsCategoryTranslateDTO
    {
        public int Id { set; get; }

        [Required]
        public int NewsCategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LanguageCulture { get; set; }
    }
}
