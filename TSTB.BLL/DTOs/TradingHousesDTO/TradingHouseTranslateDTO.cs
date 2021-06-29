using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.TradingHousesDTO
{
    public class TradingHouseTranslateDTO
    {
        public int Id { get; set; }

        [Required]
        public int TradingHouseId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string LanguageCulture { get; set; }
    }
}
