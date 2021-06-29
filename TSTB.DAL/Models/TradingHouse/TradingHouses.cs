using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.TradingHouse
{
    /// <summary>
    /// Торговые дома
    /// </summary>
    public class TradingHouses
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Person { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public bool IsPublish { set; get; }
        public ICollection<TradingHousesTranslate> TradingHousesTranslates { get; set; }
    }
}
