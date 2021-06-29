using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Departments
{
    public class Departments
    {
        public int Id { get; set; }
        public bool IsPublish { get; set; }
        public ICollection<DepartmentsTranslate> DepartmentsTranslates { get; set; }
    }
}
