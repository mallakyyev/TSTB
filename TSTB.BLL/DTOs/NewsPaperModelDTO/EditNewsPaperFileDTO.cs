using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.NewsPaperModelDTO
{
    public class EditNewsPaperFileDTO
    {
        public int Id { get; set; }

        [Required]
        public int NewsPaperDataId { get; set; }

        [Required]
        public IFormFile FormFile { get; set; }
        public string Image { get; set; }
    }
}
