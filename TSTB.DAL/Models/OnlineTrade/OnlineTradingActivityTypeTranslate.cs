using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.OnlineTrade
{
    public class OnlineTradingActivityTypeTranslate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OnlineTradingActivityTypeId { get; set; }
        public string LanguageCulture { get; set; }
        public OnlineTradingActivityType OnlineTradingActivityType { get; set; }

    }
}
