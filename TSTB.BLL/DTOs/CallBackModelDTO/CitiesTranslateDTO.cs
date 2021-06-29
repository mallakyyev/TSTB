using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.CallBackModelDTO
{
    public class CitiesTranslateDTO
    {
        public int Id { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LanguageCulture { get; set; }
    }
}
