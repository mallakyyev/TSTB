using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.IndustryModelDTO
{
    public class IndustryDTO
    {
        public int Id { get; set; }

        [Required]
        public bool IsPublish { get; set; }

        [Required]
        public string Logo { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
