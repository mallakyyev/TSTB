using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.OnlineTrade
{
    public class OnlineTradingActivityType
    {
        public int Id { get; set; }
        
        public int OnlineTradingCategoryId { get; set; }
        public OnlineTradingCategory OnlineTradingCategory { get; set; }
        public ICollection<OnlineTrading> OnlineTrading { get; set; }
        public ICollection<OnlineTradingActivityTypeTranslate> OnlineTradingActivityTypeTranslates { get; set; }
    }
}
