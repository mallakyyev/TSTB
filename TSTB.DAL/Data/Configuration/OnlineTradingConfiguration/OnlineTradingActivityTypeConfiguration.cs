using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.OnlineTrade;

namespace TSTB.DAL.Data.Configuration.OnlineTradingConfiguration
{
    class OnlineTradingActivityTypeConfiguration : IEntityTypeConfiguration<OnlineTradingActivityType>
    {
        public void Configure(EntityTypeBuilder<OnlineTradingActivityType> builder)
        {
            builder.HasKey(p => p.Id);            
            builder.Property(p => p.OnlineTradingCategoryId).IsRequired();           
            builder.HasOne(p => p.OnlineTradingCategory).WithMany(p => p.OnlineTradingActivityTypes).HasForeignKey(p => p.OnlineTradingCategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.OnlineTradingActivityTypeTranslates).WithOne(p => p.OnlineTradingActivityType).HasForeignKey(p => p.OnlineTradingActivityTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
