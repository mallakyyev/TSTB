using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.OnlineTradeDTO
{
    public class CreateOnlineTradingCategoryDTO
    {
        public int Id { get; set; }

        [Required]
        public ICollection<OnlineTradingCategoryTranslateDTO> OnlineTradingCategoryTranslates { get; set; }

        [Required]
        public bool IsPublish { get; set; }
    }
}
