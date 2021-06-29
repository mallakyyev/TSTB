using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Industry;

namespace TSTB.DAL.Data.Configuration.IndustryConfiguration
{
    class IndustryTranslateConfiguration : IEntityTypeConfiguration<IndustryTranslate>
    {
        public void Configure(EntityTypeBuilder<IndustryTranslate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IndustryId).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired(false);
            builder.Property(p => p.LanguageCulture).IsRequired();
        }
    }
}
