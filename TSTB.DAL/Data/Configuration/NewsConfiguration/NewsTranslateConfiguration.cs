using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.News;

namespace TSTB.DAL.Data.Configuration.NewsConfiguration
{
    class NewsTranslateConfiguration : IEntityTypeConfiguration<NewsTranslate>
    {
        public void Configure(EntityTypeBuilder<NewsTranslate> builder)
        {

        builder.HasKey(p => p.Id);
        builder.Property(p => p.NewsId).IsRequired();
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Description).IsRequired(false);
        builder.Property(p => p.LanguageCulture).IsRequired();

        }
    }
}
