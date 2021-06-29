using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Sayings
{
    public class Sayings
    {
        public int Id { get; set; }
        public bool IsPublish { get; set; }

        public ICollection<SayingsTranslate> SayingsTranslates { get; set; }
    }
}
