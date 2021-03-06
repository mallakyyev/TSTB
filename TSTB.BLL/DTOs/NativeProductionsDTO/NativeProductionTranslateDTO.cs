using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.NativeProductionsDTO
{
    public class NativeProductionTranslateDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int NativeProductionId { get; set; }
        [Required]
        public string LanguageCulture { get; set; }
    }
}
