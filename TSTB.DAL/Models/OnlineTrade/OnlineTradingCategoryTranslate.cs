using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.OnlineTrade
{
    public class OnlineTradingCategoryTranslate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OnlineTradingCategoryId { get; set; }
        public string LanguageCulture { get; set; }
        public OnlineTradingCategory OnlineTradingCategory { get; set; }
    }
}
