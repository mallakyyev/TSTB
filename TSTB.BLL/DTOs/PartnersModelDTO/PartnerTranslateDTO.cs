using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.PartnersModelDTO
{
    public class PartnerTranslateDTO
    {
        public int Id { get; set; }

        [Required]
        public int PartnerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LanguageCulture { get; set; }
    }
}
