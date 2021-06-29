using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.BLL.DTOs.NewsModelDTO
{
    public class CreateNewsCategoryDTO
    {
        public ICollection<NewsCategoryTranslateDTO> NewsCategoryTranslates { get; set; }
    }
}
