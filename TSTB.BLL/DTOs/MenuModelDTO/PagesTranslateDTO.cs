using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.MenuModelDTO
{
    public class PagesTranslateDTO
    {
        public int Id { get; set; }

        public int PagesId { get; set; }

        [Required]
        public string Name { get; set; }
       
        public string Description { get; set; }
       
        [Required]
        public string LanguageCulture { get; set; }
    }
}
