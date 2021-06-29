using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.OnlineTradeDTO
{
    public class EditOnlineTradingDTO
    {
        public int Id { get; set; }
        [Required]
        public ICollection<OnlineTradingTranslateDTO> OnlineTradingTranslates { get; set; }

        public List<string> PhoneNumbers { get; set; }

       
        public string Address { get; set; }

        public string Site { get; set; }


        [Required]
        public int CityId { get; set; }

        [Required]
        public int OnlineTradingActivityTypeId { get; set; }

        public IFormFile FormFile { get; set; }
        public string PictureName { get; set; }

        [Required]
        public bool IsPublish { get; set; }
    }
}
