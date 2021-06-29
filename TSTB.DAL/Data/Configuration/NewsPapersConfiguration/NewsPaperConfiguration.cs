using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.NewsPapers;

namespace TSTB.DAL.Data.Configuration.NewsPapersConfiguration
{
    class NewsPaperConfiguration : IEntityTypeConfiguration<NewsPaper>
    {
        public void Configure(EntityTypeBuilder<NewsPaper> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IsPublish).IsRequired();
            builder.HasMany(p => p.NewsPapersTranslates).WithOne(p => p.NewsPaper).HasForeignKey(p => p.NewsPaperId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.NewsPaperDatas).WithOne(p => p.NewsPaper).HasForeignKey(p => p.NewsPaperId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
