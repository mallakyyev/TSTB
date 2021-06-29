using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.ServicesDTO
{
    public class ServiceTypeDTO
    {
        public int Id { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public string ServiceCategoryName { get; set; }

        [Required]
        public bool IsPublish { get; set; }
    }
}
