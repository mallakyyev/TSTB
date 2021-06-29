using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.CharityModelDTO
{
    public class CharityDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
 
        [Required]
        public bool IsPublish { get; set; }
        public double Collected { get; set; }
    }
}
