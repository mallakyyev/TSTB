using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.ProjectsModelDTO
{
    public class ProjectTranslateDTO
    {
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        [Required]
        public string LanguageCulture { get; set; }
        
    }
}
