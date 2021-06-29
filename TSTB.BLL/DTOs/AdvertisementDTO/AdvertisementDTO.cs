using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.DTOs.AdvertisementDTO
{
    public class AdvertisementDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BannerPosition Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImageBig { get; set; }
        public string ImageSmall { get; set; }
        public string Link { get; set; }
        public int Order { get; set; }
        public bool IsPublish { get; set; }
    }
}
