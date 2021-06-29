using System;
using System.Collections.Generic;
using System.Text;

namespace TSTB.DAL.Models.Projects
{
    public class ProjectTranslate
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string LanguageCulture { get; set; }
        public Project Project { get; set; }
    }
}
