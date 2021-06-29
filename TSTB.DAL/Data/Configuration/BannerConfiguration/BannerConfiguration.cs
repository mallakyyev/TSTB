using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Banner;

namespace TSTB.DAL.Data.Configuration.BannerConfiguration
{
    class BannerConfiguration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.BannerPosition).IsRequired();
            builder.Property(p => p.EndDate).IsRequired();
            builder.Property(p => p.IsPublish).IsRequired();
            builder.Property(p => p.Link).IsRequired(false);
            builder.HasMany(p => p.BannerTranslate).WithOne(p => p.Banner).HasForeignKey(p => p.BannerId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
