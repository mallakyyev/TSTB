using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.NewsPapers;

namespace TSTB.DAL.Data.Configuration.NewsPapersConfiguration
{
    class NewsPapersTranslateConfiguration : IEntityTypeConfiguration<NewsPapersTranslate>
    {
        public void Configure(EntityTypeBuilder<NewsPapersTranslate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.NewsPaperId).IsRequired();
            builder.Property(p => p.LanguageCulture).IsRequired();
        }
    }
}
