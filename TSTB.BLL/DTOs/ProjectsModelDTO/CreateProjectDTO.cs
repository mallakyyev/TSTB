using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.BLL.DTOs.ProjectsModelDTO
{
    public class CreateProjectDTO
    {
        public ICollection<ProjectTranslateDTO> ProjectTranslates { get; set; }

        public IFormFile FormFile { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? CompleteDate{ get; set; }
        public bool IsPublish { get; set; }

    }
}
