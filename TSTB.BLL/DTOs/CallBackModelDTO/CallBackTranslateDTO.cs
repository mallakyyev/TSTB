using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.CallBackModelDTO
{
    public class CallBackTranslateDTO
    {
        public int Id { get; set; }

        [Required]
        public int CallBackId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string LanguageCulture { get; set; }
    }
}
