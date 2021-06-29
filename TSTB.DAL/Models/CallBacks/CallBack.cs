using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.DAL.Models.CallBacks
{
    public class CallBack
    {
        public int Id { get; set; }
        public string Image { get; set; }
        
        public string Phone { get; set; }
        public string Facks { get; set; }
        public string Email { get; set; }
        public bool IsPublish { get; set; }
        public WeekDay StartWeekDate { get; set; }
        public WeekDay EndWeekDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CityId { get; set; }
        public Cities Cities { get; set; }
        public ICollection<CallBackTranslate> CallBackTranslates { get; set; }
    }
}
