﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace TSTB.BLL.DTOs.PartnersModelDTO
{
    public class CreatePartnerDataDTO
    {
        public ICollection<PartnersDataTranslateDTO> PartnersDataTranslates { get; set; }

        public IFormFile FormFile { get; set; }

        public int PartnerId { get; set; }

        public bool IsPublish { get; set; }
    }
}
