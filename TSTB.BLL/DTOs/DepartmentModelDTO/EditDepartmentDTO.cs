using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.DepartmentModelDTO
{
    public class EditDepartmentDTO
    {
        public int Id { get; set; }
        public ICollection<DepartmentTranslateDTO> DepartmentsTranslates { get; set; }

        [Required]
        public bool IsPublish { get; set; }
    }
}
