using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.ApplicationUserModelDTO;
using TSTB.BLL.DTOs.OrganizationModelDTO;

namespace TSTB.Web.Areas.Admin.Models
{
    public class CreateUserAndOrganizationModel
    {
        public CreateApplicationUserDTO CraeteApplicationUserDTO { get; set; }
        public CreateOrganizationDTO CreateOrganizationDTO { get; set; }
    }
}
