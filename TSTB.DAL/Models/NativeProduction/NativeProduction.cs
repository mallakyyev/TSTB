using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.NativeProduction
{
    public class NativeProduction
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool IsPublish { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<NativeProductionTranslate> NativeProductionTranslates { get; set; }
    }
}
