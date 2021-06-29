using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

using TSTB.DAL.Models.Projects;

namespace TSTB.DAL.Data.Configuration.ProjectsConfiguration
{
    class ProjectsConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Image).IsRequired(false);
            builder.Property(p => p.StartDate).IsRequired(false);
            builder.Property(p => p.EndDate).IsRequired(false);
            builder.Property(p => p.IsPublish).IsRequired();
            builder.Property(p => p.CompleteDate).IsRequired(false);
            builder.HasMany(p => p.ProjectTranslates).WithOne(p => p.Project).HasForeignKey(p => p.ProjectId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
