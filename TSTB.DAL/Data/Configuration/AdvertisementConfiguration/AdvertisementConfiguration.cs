using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Advertisement;

namespace TSTB.DAL.Data.Configuration.AdvertisementConfiguration
{
    class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Link).IsRequired(false);
            builder.Property(p => p.Order).IsRequired(false);
            builder.Property(p => p.IsPublish).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Position).IsRequired();
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.EndDate).IsRequired();
            builder.Property(p => p.ImageBig).IsRequired();
            builder.Property(p => p.ImageSmall).IsRequired();

        }
    }
}
