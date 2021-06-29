using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.OnlineTradeDTO
{
    public class CreateOnlineTradingActivityTypeDTO
    {
        public int Id { get; set; }

        [Required]
        public ICollection<OnlineTradingActivityTypeTranslateDTO> OnlineTradingActivityTypeTranslates { get; set; }

        [Required]
        public int OnlineTradingCategoryId { get; set; }
    }
}
