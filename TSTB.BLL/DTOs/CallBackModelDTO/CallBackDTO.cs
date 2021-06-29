using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.DTOs.CallBackModelDTO
{
    public class CallBackDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Facks { get; set; }
        [Required]
        public string Email { get; set; }

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
    }
}
