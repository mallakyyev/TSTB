using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TSTB.DAL.Models.NewsPapers;

namespace TSTB.BLL.DTOs.NewsPaperModelDTO
{
    public class NewsPaperDataDTO
    {
        public int Id { get; set; }

        [Required]
        public int NewsPaperId { get; set; }

        public string Image { get; set; }

        [Required]
        public DateTime DataOfPublish { get; set; }

        [Required]
        public bool IsPublish { get; set; }
        public string NewsPaperName { get; set; }
       
    }
}
