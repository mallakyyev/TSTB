using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.WidgetModelDTO
{
    public class EditWidgetDTo
    {
        public int Id { get; set; }

        public ICollection<WidgetTranslateDTO> WidgetTranslates { get; set; }

        [Required]
        public bool IsPublish { get; set; }

        public string Link { get; set; }

        [Required]
        public int Order { get; set; }

        public IFormFile SVG { get; set; }

        public string LogoName { get; set; }
    }
}
