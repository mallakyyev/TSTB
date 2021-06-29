using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.NativeProduction;

namespace TSTB.DAL.Data.Configuration.NativeProductionConfiguration
{
    class NativeProductionTranslateConfiguration : IEntityTypeConfiguration<NativeProductionTranslate>
    {
        public void Configure(EntityTypeBuilder<NativeProductionTranslate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.NativeProductionId).IsRequired();           
        }
    }
}
