using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.TradingHouse
{
    public class TradingHousesTranslate
    {
        public int Id { get; set; }
        public int TradingHouseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LanguageCulture { get; set; }
        public TradingHouses TradingHouses { get; set; }
    }
}
