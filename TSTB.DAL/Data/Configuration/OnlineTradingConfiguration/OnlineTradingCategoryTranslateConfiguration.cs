using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.OnlineTrade;

namespace TSTB.DAL.Data.Configuration.OnlineTradingConfiguration
{
    class OnlineTradingCategoryTranslateConfiguration : IEntityTypeConfiguration<OnlineTradingCategoryTranslate>
    {
        public void Configure(EntityTypeBuilder<OnlineTradingCategoryTranslate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();            
            builder.Property(p => p.LanguageCulture).IsRequired();
            builder.Property(p => p.OnlineTradingCategoryId).IsRequired();
        }
    
    }
}
