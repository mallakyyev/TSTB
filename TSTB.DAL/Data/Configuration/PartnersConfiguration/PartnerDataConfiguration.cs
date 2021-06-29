using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Partners;

namespace TSTB.DAL.Data.Configuration.PartnersConfiguration
{
    class PartnerDataConfiguration : IEntityTypeConfiguration<PartnersData>
    {
        public void Configure(EntityTypeBuilder<PartnersData> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.PartnerId).IsRequired();
            builder.Property(p => p.Image).IsRequired(false);
            builder.Property(p => p.IsPublish).IsRequired();
            builder.HasMany(p => p.PartnersDataTranslates).WithOne(p => p.PartnersData).HasForeignKey(p => p.PartnersDataId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
