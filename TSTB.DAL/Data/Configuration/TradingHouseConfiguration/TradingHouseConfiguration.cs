using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.TradingHouse;

namespace TSTB.DAL.Data.Configuration.TradingHouseConfiguration
{
    class TradingHouseConfiguration : IEntityTypeConfiguration<TradingHouses>
    {
        public void Configure(EntityTypeBuilder<TradingHouses> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Person).IsRequired();
            builder.Property(p => p.Address).IsRequired();
            builder.Property(p => p.Phone).IsRequired();
            builder.Property(p => p.Site).IsRequired(false);
            builder.Property(p => p.Email).IsRequired(false);
            builder.Property(p => p.IsPublish).IsRequired();
            builder.Property(p => p.Image).IsRequired(false);
            builder.HasMany(p => p.TradingHousesTranslates).WithOne(p => p.TradingHouses).HasForeignKey(p => p.TradingHouseId).OnDelete(DeleteBehavior.Cascade);
        }
        
    }
}
