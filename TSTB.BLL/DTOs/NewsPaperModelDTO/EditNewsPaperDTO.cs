using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.NewsPaperModelDTO
{
    public class EditNewsPaperDTO
    {
        public int Id { get; set; }
        public ICollection<NewsPaperTranslateDTO> NewsPapersTranslates { get; set; }

        //public EditNewsPaperDataDTO EditNewsPaperData { get; set; }

        //public ICollection<EditNewsPaperFileDTO> EditNewsPaperFiles { get; set; }

        [Required]
        public bool IsPublish { get; set; }
    }
}
