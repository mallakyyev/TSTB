using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TSTB.BLL.Services.ImageService
{
    public interface IImageService
    {
        public Task<string> UploadImage(IFormFile formFile, string pClass);
        public bool DeleteImage(string pictureName,string pClass);
    }
}
