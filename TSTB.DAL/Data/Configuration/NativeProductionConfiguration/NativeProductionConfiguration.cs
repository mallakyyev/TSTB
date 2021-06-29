using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.NativeProduction;

namespace TSTB.DAL.Data.Configuration.NativeProductionConfiguration
{
    public class NativeProductionConfiguration : IEntityTypeConfiguration<NativeProduction>
    {
        public void Configure(EntityTypeBuilder<NativeProduction> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Image).IsRequired();
        builder.Property(p => p.IsPublish).IsRequired();
        builder.Property(p => p.CreatedDate).IsRequired();        
        builder.HasMany(p => p.NativeProductionTranslates).WithOne(p => p.NativeProduction).HasForeignKey(p => p.NativeProductionId).OnDelete(DeleteBehavior.Cascade);
    }
}
}
