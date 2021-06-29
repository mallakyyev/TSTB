using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using TSTB.DAL.Models.CurrencyRate;

namespace TSTB.BLL.ViewModel
{
    [XmlRoot("cbt_currency_rate")]
    public class ListCurrency
    {
        public ListCurrency()
        {
            CurrencyRates = new List<CurrencyRate>();
        }
        [XmlElement("rate")]
        public List<CurrencyRate> CurrencyRates { get; set; }
    }
}
