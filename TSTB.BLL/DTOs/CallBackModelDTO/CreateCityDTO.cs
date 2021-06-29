using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.BLL.DTOs.CallBackModelDTO
{
    public class CreateCityDTO
    {
        public ICollection<CitiesTranslateDTO> CitiesTranslates { get; set; }
    }
}
