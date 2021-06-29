using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.OnlineTrade
{
    public class OnlineTradingCategory
    {
        public int Id { get; set; }
        
        public bool IsPublish { get; set; }
        public ICollection<OnlineTradingActivityType>  OnlineTradingActivityTypes { get; set; }
        public ICollection<OnlineTradingCategoryTranslate> OnlineTradingCategoryTranslates { get; set; }
    }
}
