using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.PartnersModelDTO;

namespace TSTB.Web.Areas.Admin.Models
{
    public class EditPartnerAndDataModel
    {
        public EditPartnerDTO EditPartnerDTO { get; set; }
        public EditPartnerDataDTO EditPartnerDataDTO { get; set; }
    }
}
