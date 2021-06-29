﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.NewsPaperModelDTO
{
    public class EditNewsPaperDataDTO
    {
        public int Id { get; set; }

        [Required]
        public int NewsPaperId { get; set; }

        public IFormFile FormFile { get; set; }
        public IEnumerable<IFormFile> FormFiles { get; set; }
        
        [Required]
        public DateTime DataOfPublish { get; set; }
        public string Image { get; set; }
        [Required]
        public bool IsPublish { get; set; }
    }
}
