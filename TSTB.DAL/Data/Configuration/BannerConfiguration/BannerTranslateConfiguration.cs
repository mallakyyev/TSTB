using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Banner;

namespace TSTB.DAL.Data.Configuration.BannerConfiguration
{
    public class BannerTranslateConfiguration : IEntityTypeConfiguration<BannerTranslate>
    {
        public void Configure(EntityTypeBuilder<BannerTranslate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.BannerId).IsRequired();
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.ShortDescription).IsRequired();
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p => p.LanguageCulture).IsRequired();
        }
    
       
    }
}
