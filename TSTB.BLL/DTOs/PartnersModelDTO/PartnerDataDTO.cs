using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.PartnersModelDTO
{
    public class PartnerDataDTO
    {
        public int Id { get; set; }

        [Required]
        public int PartnerId { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }
        public bool IsPublish { get; set; }

        public PartnersDTO Partners { get; set; }
    }
}
