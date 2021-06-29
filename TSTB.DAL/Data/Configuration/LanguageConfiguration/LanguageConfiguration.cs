using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Language;

namespace TSTB.DAL.Data.Configuration.LanguageConfiguration
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(p => p.Culture);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.FlagImage).IsRequired(false);
            builder.Property(p => p.IsPublish).IsRequired();
            builder.Property(p => p.DisplayOrder).IsRequired();
        }
    }
}
