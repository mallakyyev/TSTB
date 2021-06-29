using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.TradingHouse;

namespace TSTB.DAL.Data.Configuration.TradingHouseConfiguration
{
    public class TradingHouseTranslateConfiguration : IEntityTypeConfiguration<TradingHousesTranslate>
    {
        public void Configure(EntityTypeBuilder<TradingHousesTranslate> builder)
        {
     
            builder.HasKey(p => p.Id);
            builder.Property(p => p.TradingHouseId).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired(false);
            builder.Property(p => p.LanguageCulture).IsRequired();
        }
    }
}
