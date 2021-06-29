using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.CurrencyRate;

namespace TSTB.DAL.Data.Configuration.CurrencyRateConfiguration
{
    class CurrencyRateConfiguration : IEntityTypeConfiguration<CurrencyRate>
    {
        public void Configure(EntityTypeBuilder<CurrencyRate> builder)
        {
            builder.HasKey(p => p.code);
            builder.Property(p => p.name).IsRequired();
            builder.Property(p => p.rate_tmt).IsRequired();
            builder.Property(p => p.rate_usd).IsRequired();
            builder.Property(p => p.multiplier).IsRequired();
            builder.Property(p => p.checksum).IsRequired();
            //builder.HasMany(p => p.DepartmentsTranslates).WithOne(p => p.Departments).HasForeignKey(p => p.DepartmentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
