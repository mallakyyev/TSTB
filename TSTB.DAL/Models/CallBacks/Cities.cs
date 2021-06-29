using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.OnlineTrade;
using TSTB.DAL.Models.User;

namespace TSTB.DAL.Models.CallBacks
{
    public class Cities
    {
        public int Id { get; set; }
        public ICollection<CallBack> CallBacks { get; set; }
        public ICollection<CitiesTranslate> CitiesTranslates { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public ICollection<OnlineTrading> OnlineTrading { get; set; }
    }
}
