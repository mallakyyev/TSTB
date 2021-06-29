using System;
using System.Collections.Generic;
using System.Text;
using TSTB.BLL.DTOs.OnlineTradeDTO;
using TSTB.DAL.Models.OnlineTrade;

namespace TSTB.BLL.ViewModel
{
    public class OnlineTradingModel
    {
        public int Id { get; set; }
        public string OnlineTradingCategoryName { get; set; }
        public IEnumerable<OnlineTradingDTO> OnlineTradings { get; set; }
    }
}
