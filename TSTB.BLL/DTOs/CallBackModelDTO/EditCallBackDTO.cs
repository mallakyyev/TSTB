using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.DTOs.CallBackModelDTO
{
    public class EditCallBackDTO
    {
        public int CityId { get; set; }
        public int Id { get; set; }
        public IFormFile FormFile { get; set; }


        [Required]
        public string Phone { get; set; }

        public string Facks { get; set; }
        [Required]
        public string Email { get; set; }
        public string PictureName { get; set; }

        [Required]
        public bool IsPublish { get; set; }

        [Required]
        public WeekDay StartWeekDate { get; set; }

        [Required]
        public WeekDay EndWeekDate { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public ICollection<CallBackTranslateDTO> CallBackTranslates { get; set; }
    }
}
