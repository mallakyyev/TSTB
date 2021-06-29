using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.SayingsDTO
{
    public class EditSayingsDTO
    {
        public int Id { get; set; }

        [Required]
        public ICollection<SayingsTranslateDTO> SayingsTranslates { get; set; }

        [Required]
        public bool IsPublish { get; set; }
    }
}
