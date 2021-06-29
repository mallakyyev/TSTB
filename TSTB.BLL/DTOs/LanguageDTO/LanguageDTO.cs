using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.LanguageDTO
{
    public class LanguageDTO
    {
        [Required]
        public string Culture { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsPublish { get; set; }

        public string FlagImage { get; set; }

        public int DisplayOrder { get; set; }
    }
}
