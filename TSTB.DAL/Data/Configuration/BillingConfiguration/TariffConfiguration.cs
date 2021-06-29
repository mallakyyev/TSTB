using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Billing;

namespace TSTB.DAL.Data.Configuration.BillingConfiguration
{
    class TariffConfiguration : IEntityTypeConfiguration<Tariff>
    {
        public void Configure(EntityTypeBuilder<Tariff> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.EntryAmount).IsRequired();
            builder.Property(p => p.EntreprenuerType).IsRequired();
            builder.Property(p => p.Name).IsRequired();

        }
    }
}
