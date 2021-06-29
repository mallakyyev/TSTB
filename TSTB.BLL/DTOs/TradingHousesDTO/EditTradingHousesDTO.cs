using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.TradingHousesDTO
{
    public class EditTradingHousesDTO
    {
        public int Id { get; set; }
        public ICollection<TradingHouseTranslateDTO> TradingHousesTranslates { get; set; }

        [Required]
        public string Person { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Email { get; set; }

        public string Site { get; set; }

        [Required]
        public bool IsPublish { set; get; }

        public IFormFile FormFile { get; set; }

        public string Image { get; set; }
    }
}
