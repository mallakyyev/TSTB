using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.BLL.DTOs.CallBackModelDTO
{
    public class EditCityDTO
    {
        public int Id { get; set; }

        public ICollection<CitiesTranslateDTO> CitiesTranslates { get; set; }
    }
}
