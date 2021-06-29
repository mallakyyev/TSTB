using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.NewsPaperModelDTO
{
    public class CreateNewsPaperDTO
    {
        public ICollection<NewsPaperTranslateDTO> NewsPapersTranslates { get; set; }

        //public CreateNewsPaperDataDTO NewsPaperDataDTO { get; set; }

        //public ICollection<CreateNewsPaperFileDTO> NewsPaperFilesDTO { get; set; }        

        [Required]
        public bool IsPublish { get; set; }

    }
}
