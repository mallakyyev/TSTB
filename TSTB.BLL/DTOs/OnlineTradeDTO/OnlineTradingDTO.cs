using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.OnlineTradeDTO
{
    public class OnlineTradingDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
       
        public string PhoneNumber { get; set; }
       
        public string Address { get; set; }
        
        public string Site { get; set; }

        public string Description { get; set; }

        public int CityId { get; set; }
        public string CityName { get; set; }

        public int OnlineTradingActivityTypeId { get; set; }
        public string Image { get; set; }
        public string ActivityTypeName { get; set; }
        public string ActivityName { get; set; }
        public bool IsPublish { get; set; }
   
    }
}
