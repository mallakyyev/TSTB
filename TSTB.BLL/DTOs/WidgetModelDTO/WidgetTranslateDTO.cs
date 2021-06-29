using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.WidgetModelDTO
{
    public class WidgetTranslateDTO
    {
        public int Id { get; set; }
        
        public string Footer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WidgetID { get; set; }
        public string LanguageCulture { get; set; }
    }
}
