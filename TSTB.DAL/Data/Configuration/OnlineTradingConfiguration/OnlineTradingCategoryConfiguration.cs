using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.OnlineTrade;

namespace TSTB.DAL.Data.Configuration.OnlineTradingConfiguration
{
    class OnlineTradingCategoryConfiguration : IEntityTypeConfiguration<OnlineTradingCategory>
    {
        public void Configure(EntityTypeBuilder<OnlineTradingCategory> builder)
        {
            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.IsPublish).IsRequired();
            builder.HasMany(p => p.OnlineTradingCategoryTranslates).WithOne(p => p.OnlineTradingCategory).HasForeignKey(p => p.OnlineTradingCategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
