using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.News;

namespace TSTB.DAL.Data.Configuration.NewsConfiguration
{
    class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NewsCategoryID).IsRequired();
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p => p.DatePublished).IsRequired();
            builder.Property(p => p.IsPublish).IsRequired();
            builder.HasMany(p => p.NewsTranslates).WithOne(p => p.News).HasForeignKey(p => p.NewsId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
