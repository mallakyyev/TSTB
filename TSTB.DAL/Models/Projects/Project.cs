using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Projects
{
    public class Project
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public bool IsPublish { get; set; }
        public ICollection<ProjectTranslate> ProjectTranslates { get; set; }

    }
}
