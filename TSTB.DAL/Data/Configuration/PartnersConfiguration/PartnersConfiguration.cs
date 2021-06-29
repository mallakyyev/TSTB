using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Partners;

namespace TSTB.DAL.Data.Configuration.PartnersConfiguration
{
    class PartnersConfiguration : IEntityTypeConfiguration<Partners>
    {
        public void Configure(EntityTypeBuilder<Partners> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Order).IsRequired();
            builder.Property(p => p.Logo).IsRequired(false);
       
            builder.Property(p => p.IsPublish).IsRequired();
            builder.HasOne(p => p.PartnersData).WithOne(p => p.Partners).HasForeignKey<PartnersData>(p => p.PartnerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.PartnerTranslates).WithOne(p => p.Partners).HasForeignKey(p => p.PartnerId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
