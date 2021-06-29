using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSTB.BLL.DTOs.NewsPaperModelDTO;

namespace TSTB.Web.Areas.Admin.Models
{
    public class CreateNewsPaperDataAndFilesModel
    {
        public EditNewsPaperDataDTO CreateNewsPaperDataDTO { get; set; }
        public ICollection<EditNewsPaperFileDTO> CreateNewsPaperFilesDTO { get; set; }
    }
}
