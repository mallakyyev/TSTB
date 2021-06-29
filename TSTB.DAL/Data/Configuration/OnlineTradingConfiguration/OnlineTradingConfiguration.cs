using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.OnlineTrade;

namespace TSTB.DAL.Data.Configuration.OnlineTradingConfiguration
{
    class OnlineTradingConfiguration : IEntityTypeConfiguration<OnlineTrading>
    {
        public void Configure(EntityTypeBuilder<OnlineTrading> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CityId).IsRequired();
            builder.Property(p => p.Address).IsRequired(false);
            builder.Property(p => p.IsPublish).IsRequired();            
            builder.Property(p => p.Image).IsRequired(false);            
            builder.Property(p => p.PhoneNumber).IsRequired(false);
            builder.Property(p => p.Site).IsRequired(false);
            builder.Property(p => p.OnlineTradingActivityTypeId).IsRequired();
            builder.HasOne(p => p.OnlineTradingActivityType).WithMany(p => p.OnlineTrading).HasForeignKey(p => p.OnlineTradingActivityTypeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Cities).WithMany(p => p.OnlineTrading).HasForeignKey(p => p.CityId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.OnlineTradingTranslates).WithOne(p => p.OnlineTrading).HasForeignKey(p => p.OnlineTradingId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
