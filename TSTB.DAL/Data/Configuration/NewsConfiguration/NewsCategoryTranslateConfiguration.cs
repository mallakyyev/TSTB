using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.News;

namespace TSTB.DAL.Data.Configuration.NewsConfiguration
{
    class NewsCategoryTranslateConfiguration : IEntityTypeConfiguration<NewsCategoryTranslate>
    {
        public void Configure(EntityTypeBuilder<NewsCategoryTranslate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NewsCategoryId).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.LanguageCulture).IsRequired();
        }
    }
}
