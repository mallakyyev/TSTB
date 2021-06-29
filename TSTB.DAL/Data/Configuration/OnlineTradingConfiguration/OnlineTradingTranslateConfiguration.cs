using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.OnlineTrade;

namespace TSTB.DAL.Data.Configuration.OnlineTradingConfiguration
{
    class OnlineTradingTranslateConfiguration : IEntityTypeConfiguration<OnlineTradingTranslate>
    {
        public void Configure(EntityTypeBuilder<OnlineTradingTranslate> builder)
        {
            builder.HasKey(p => p.Id);           
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.LanguageCulture).IsRequired();
            builder.Property(p => p.OnlineTradingId).IsRequired();
        }

    }
}
