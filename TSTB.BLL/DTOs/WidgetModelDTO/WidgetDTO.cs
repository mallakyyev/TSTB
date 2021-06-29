using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.WidgetModelDTO
{
    public class WidgetDTO
    {
        public int Id { get; set; }
       
        public string Logo { get; set; }
        public bool IsPublish { get; set; }
        public string Footer { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }        
        public int Order { get; set; }
        public string Description { get; set; }
    }
}
