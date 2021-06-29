using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Widget
{
    public class WidgetTranslate
    {
        public int Id { get; set; }
        public string Footer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WidgetID { get; set; }
        public string LanguageCulture { get; set; }
        public Widget Widget { get; set; }
    }
}
