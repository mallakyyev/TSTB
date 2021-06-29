using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Projects;

namespace TSTB.DAL.Data.Configuration.ProjectsConfiguration
{
    class ProjectsTranslateConfiguration : IEntityTypeConfiguration<ProjectTranslate>
    {
        public void Configure(EntityTypeBuilder<ProjectTranslate> builder)
        {
     
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ProjectId).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired(false);
            builder.Property(p => p.ShortDescription).IsRequired(false);
            builder.Property(p => p.LanguageCulture).IsRequired();
        }
    }
}
