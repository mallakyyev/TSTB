using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.OnlineTrade
{
    public class OnlineTradingTranslate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OnlineTradingId { get; set; }
        public string LanguageCulture { get; set; }
        public OnlineTrading OnlineTrading { get; set; }
    }
}
