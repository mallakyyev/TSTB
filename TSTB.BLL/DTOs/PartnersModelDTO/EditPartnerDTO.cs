using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace TSTB.BLL.DTOs.PartnersModelDTO
{
    public class EditPartnerDTO
    {
        public int Id { get; set; }

        public ICollection<PartnerTranslateDTO> PartnerTranslates { get; set; }

        public int Order { get; set; }
        public IFormFile FormFile { get; set; }
        public string LogoName { get; set; }
        public string Image { get; set; }
        public bool IsPublish { get; set; }
    }
}
