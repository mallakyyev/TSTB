using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TSTB.DAL.Models.Enums;

namespace TSTB.BLL.DTOs.BannerModelDTO
{
    public class BannerDTO
    {
        public int Id { get; set; }

        public BannerPosition BannerPosition { get; set; }
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Image { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsPublish { get; set; }

        public string Link { get; set; }
    }
}
