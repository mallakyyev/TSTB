using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.BLL.DTOs.NativeProductionsDTO
{
    public class EditNativeProductionDTO
    {
        public int Id { get; set; }
        public ICollection<NativeProductionTranslateDTO> NativeProductionTranslates { get; set; }
        public IFormFile FormFile { get; set; }
        public string PictureName { get; set; }
        public bool IsPublish { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
