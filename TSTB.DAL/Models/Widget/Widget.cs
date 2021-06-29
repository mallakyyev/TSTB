using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Widget
{
    public class Widget
    {
        public int Id { get; set; }        
        public string Logo { get; set; }
        public bool IsPublish { get; set; }
        public string Link { get; set; }
        public int Order { get; set; }
        public ICollection<WidgetTranslate> WidgetTranslates { get; set; }
    }
}
