using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.BLL.DTOs.NativeProductionsDTO
{
    public class CreateNativeProductionDTO
    {
        public ICollection<NativeProductionTranslateDTO> NativeProductionTranslates { get; set; }
        public IFormFile FormFile { get; set; }

        public bool IsPublish { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
