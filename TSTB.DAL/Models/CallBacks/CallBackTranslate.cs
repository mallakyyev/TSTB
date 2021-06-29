using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.CallBacks
{
    public class CallBackTranslate
    {
        public int Id { get; set; }
        public int CallBackId { get; set; }
        public string Address { get; set; }
        public string LanguageCulture { get; set; }
        public CallBack CallBack{ get; set; }
    }
}
