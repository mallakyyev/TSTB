using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.CallBacks
{
    public class CitiesTranslate
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public Cities Cities { get; set; }
    }
}
