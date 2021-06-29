using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TSTB.DAL.Models.CurrencyRate
{
    public class CurrencyRate
    {
        [XmlAttribute("code")]
        public string code { get; set; }

        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("rate_usd")]
        public double rate_usd { get; set; }

        [XmlElement("multiplier")]
        public int multiplier { get; set; }

        [XmlElement("rate_tmt")]
        public double rate_tmt { get; set; }

        [XmlElement("checksum")]
        public string checksum { get; set; }
    }
}
