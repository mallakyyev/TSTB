using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.NewsPaperModelDTO
{
    public class NewsPaperDTO
    {
        public int Id { get; set; }

        [Required]
        public bool IsPublish { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
