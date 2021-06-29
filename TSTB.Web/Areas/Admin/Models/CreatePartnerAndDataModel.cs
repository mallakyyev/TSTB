using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.PartnersModelDTO;

namespace TSTB.Web.Areas.Admin.Models
{
    public class CreatePartnerAndDataModel
    {
        public CreatePartnerDTO CreatePartnerDTO { get; set; }
        public CreatePartnerDataDTO CreatePartnerDataDTO { get; set; }
    }
}
