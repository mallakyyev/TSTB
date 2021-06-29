using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Services;

namespace TSTB.DAL.Data.Configuration.ServicesConfiguration
{
    class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceType>
    {
        public void Configure(EntityTypeBuilder<ServiceType> builder)
        {
  
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ServiceId).IsRequired();
            builder.Property(p => p.IsPublish).IsRequired();
            builder.HasMany(p => p.ServiceTypeTranslates).WithOne(p => p.ServiceType).HasForeignKey(p => p.ServiceTypeId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
