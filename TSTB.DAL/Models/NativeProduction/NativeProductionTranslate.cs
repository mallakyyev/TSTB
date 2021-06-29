using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.NativeProduction
{
    public class NativeProductionTranslate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NativeProductionId { get; set; }
        public NativeProduction NativeProduction { get; set; }
        public string LanguageCulture { get; set; }
    }
}
