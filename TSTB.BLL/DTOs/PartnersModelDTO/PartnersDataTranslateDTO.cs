using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.PartnersModelDTO
{
    public class PartnersDataTranslateDTO
    {
        public int Id { get; set; }

        [Required]
        public int PartnersDataId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string LanguageCulture { get; set; }
    }
}
