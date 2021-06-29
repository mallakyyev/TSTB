using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Departments;

namespace TSTB.DAL.Data.Configuration.DepartmentsConfiguration
{
    class DepartmentsTranslateConfiguration : IEntityTypeConfiguration<DepartmentsTranslate>
    {
        public void Configure(EntityTypeBuilder<DepartmentsTranslate> builder)
        {
      
            builder.HasKey(p => p.Id);
            builder.Property(p => p.DepartmentId).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired(false);
            builder.Property(p => p.LanguageCulture).IsRequired();
            builder.HasOne(p => p.Departments).WithMany(p => p.DepartmentsTranslates).HasForeignKey(p => p.DepartmentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
