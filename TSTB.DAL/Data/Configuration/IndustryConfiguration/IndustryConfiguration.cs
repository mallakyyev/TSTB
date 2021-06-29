using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Industry;

namespace TSTB.DAL.Data.Configuration.IndustryConfiguration
{
    class IndustryConfiguration : IEntityTypeConfiguration<Industry>
    {
        public void Configure(EntityTypeBuilder<Industry> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IsPublish).IsRequired();
            builder.Property(p => p.Logo).IsRequired();
            builder.HasMany(p => p.IndustryTranslates).WithOne(p => p.Industry).HasForeignKey(p => p.IndustryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
