using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.DepartmentModelDTO
{
    public class DepartmentTranslateDTO
    {
        public int Id { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string LanguageCulture { get; set; }
    }
}
