using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Departments;

namespace TSTB.DAL.Data.Configuration.DepartmentsConfiguration
{
    class DepartmentsConfiguration : IEntityTypeConfiguration<Departments>
    {
        public void Configure(EntityTypeBuilder<Departments> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IsPublish).IsRequired();
            //builder.HasMany(p => p.DepartmentsTranslates).WithOne(p => p.Departments).HasForeignKey(p => p.DepartmentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
