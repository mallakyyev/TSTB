using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Services;

namespace TSTB.DAL.Data.Configuration.ServicesConfiguration
{
    class ServicesConfiguration : IEntityTypeConfiguration<Services>
    {
        public void Configure(EntityTypeBuilder<Services> builder)
        {
           
         builder.HasKey(p => p.Id);
         builder.Property(p => p.IsPublish).IsRequired();
         builder.Property(p => p.Logo).IsRequired();
         builder.Property(p => p.VideoLink).IsRequired();
         builder.HasMany(p => p.ServiceTypes).WithOne(p => p.Services).HasForeignKey(p => p.ServiceId).OnDelete(DeleteBehavior.Cascade);
         builder.HasMany(p => p.ServiceTranslates).WithOne(p => p.Services).HasForeignKey(p => p.ServiceId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
