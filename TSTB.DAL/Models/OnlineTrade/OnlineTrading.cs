using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.CallBacks;

namespace TSTB.DAL.Models.OnlineTrade
{
    public class OnlineTrading
    {
        public int Id { get; set; }        
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Site { get; set; }        
        public int CityId { get; set; }
        public int OnlineTradingActivityTypeId { get; set; }
        public string Image { get; set; }
        public bool IsPublish { get; set; }
        public OnlineTradingActivityType OnlineTradingActivityType { get; set; }
        public Cities Cities { get; set; }
        public ICollection<OnlineTradingTranslate> OnlineTradingTranslates { get; set; }
    }
}
