using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.ProjectsModelDTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        public DateTime? CompleteDate { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        [Required]
        public bool IsPublish { get; set; }
    }
}
