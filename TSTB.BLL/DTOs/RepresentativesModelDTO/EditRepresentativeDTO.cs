using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace TSTB.BLL.DTOs.RepresentativesModelDTO
{
    public class EditRepresentativeDTO
    {
        public int Id { get; set; }

        public IFormFile FormFile { get; set; }

        public ICollection<RepresentativeTranslateDTO> RepresentativesTranslates { get; set; }

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
        public string Image { get; set; }
    }
}
