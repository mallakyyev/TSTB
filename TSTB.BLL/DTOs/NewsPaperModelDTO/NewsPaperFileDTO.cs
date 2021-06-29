using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.NewsPaperModelDTO
{
    public class NewsPaperFileDTO
    {
        public int Id { get; set; }

        [Required]
        public int NewsPaperDataId { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
