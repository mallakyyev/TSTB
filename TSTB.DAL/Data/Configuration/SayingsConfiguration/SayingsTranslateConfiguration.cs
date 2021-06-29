using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Sayings;

namespace TSTB.DAL.Data.Configuration.SayingsConfiguration
{
    class SayingsTranslateConfiguration :  IEntityTypeConfiguration<SayingsTranslate>
    {
        public void Configure(EntityTypeBuilder<SayingsTranslate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.SayingsId).IsRequired();
            builder.Property(p => p.Author).IsRequired();
            builder.Property(p => p.AuthorPosition).IsRequired();
            builder.Property(p => p.LanguageCulture).IsRequired();
            builder.Property(p => p.SayingsText).IsRequired();
        }
    }
}
