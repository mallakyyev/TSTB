using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.BLL.DTOs.ProjectsModelDTO
{
    public class EditProjectsDTO
    {

        public int Id { get; set; }
        public ICollection<ProjectTranslateDTO> ProjectTranslates { get; set; }

        public IFormFile FormFile { get; set; }
        public string PictureName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? CompleteDate { get; set; }
        public bool IsPublish { get; set; }
        public bool DeleteImage { get; set; }
    }
}
