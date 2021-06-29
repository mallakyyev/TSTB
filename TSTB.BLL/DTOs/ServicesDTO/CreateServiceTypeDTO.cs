using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.ServicesDTO
{
    public class CreateServiceTypeDTO
    {
        public ICollection<ServiceTypeTranslateDTO> ServiceTypeTranslates { get; set; }
        
        [Required]
        public int ServiceId { get; set; }

        [Required]
        public bool IsPublish { get; set; }
    }
}
