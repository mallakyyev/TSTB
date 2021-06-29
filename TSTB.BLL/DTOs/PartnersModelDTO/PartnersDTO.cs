using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.PartnersModelDTO
{
    public class PartnersDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Order { get; set; }

        public string LogoFullPath { get; set; }
        public string Logo { get; set; }
     
        [Required]
        public bool IsPublish { get; set; }
    }
}
