using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.BLL.DTOs.OnlineTradeDTO
{
    public class OnlineTradingActivityTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int OnlineTradingCategoryId { get; set; }
      
    }
}
