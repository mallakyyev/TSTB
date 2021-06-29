using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.MenuModelDTO;

namespace TSTB.Web.Models
{
    public class MenuPagesCreateModel
    {
        public CreateMenuDTO CreateMenuDTO { get; set; }
        public CreatePagesDTO CreatePagesDTO { get; set; }
    }
}
