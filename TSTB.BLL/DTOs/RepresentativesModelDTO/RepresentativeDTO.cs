using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.RepresentativesModelDTO
{
    public class RepresentativeDTO
    {
        public int Id { get; set; }
        public string Image { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Person { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Site { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public bool IsPublish { get; set; }
    }
}
