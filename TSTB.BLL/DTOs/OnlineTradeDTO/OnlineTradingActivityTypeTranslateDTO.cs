using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.OnlineTradeDTO
{
    public class OnlineTradingActivityTypeTranslateDTO
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }

        [Required]
        public string LanguageCulture { get; set; }

        [Required]
        public int OnlineTradingActivityTypeId { get; set; }
    }
}
