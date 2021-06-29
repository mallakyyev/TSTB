using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.BLL.DTOs.NewsModelDTO
{
    public class EditNewsCategoryDTO
    {
        public int Id { get; set; }
        public ICollection<NewsCategoryTranslateDTO> NewsCategoryTranslates { get; set; }
    }
}
