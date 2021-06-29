using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.News;

namespace TSTB.DAL.Data.Configuration.NewsConfiguration
{
    class NewsCategoryConfiguration : IEntityTypeConfiguration<NewsCategory>
    {
        public void Configure(EntityTypeBuilder<NewsCategory> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.News).WithOne(p => p.NewsCategory).HasForeignKey(p => p.NewsCategoryID).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.NewsCategoryTranslates).WithOne(p => p.NewsCategory).HasForeignKey(p => p.NewsCategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
