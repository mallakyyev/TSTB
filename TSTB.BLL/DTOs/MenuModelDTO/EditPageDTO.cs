using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.MenuModelDTO
{
    public class EditPageDTO
    {
        public int Id { get; set; }

        public ICollection<PagesTranslateDTO> PagesTranslates { get; set; }

        public int? MenuId { get; set; }

        [Required]
        public bool IsPublish { get; set; }
    }
}
