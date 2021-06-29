using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.NativeProductionsDTO
{
    public class NativeProdutionDTO
    {
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public bool IsPublish { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
       
    }
}
