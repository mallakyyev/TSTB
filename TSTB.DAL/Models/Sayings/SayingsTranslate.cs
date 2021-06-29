using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Sayings
{
    public class SayingsTranslate
    {
        public int Id { get; set; }
        public int SayingsId { get; set; }
        public string Author { get; set; }
        public string AuthorPosition { get; set; }
        public string SayingsText { get; set; }
        public string LanguageCulture { get; set; }

        public Sayings Sayings { get; set; }

    }
}
