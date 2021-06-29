using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Representatives;

namespace TSTB.DAL.Data.Configuration.RepresentativesConfiguration
{
    class RepresentativesConfiguration : IEntityTypeConfiguration<Representatives>
    {
        public void Configure(EntityTypeBuilder<Representatives> builder)
        { 
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Image).IsRequired(false);
            builder.Property(p => p.Person).IsRequired();
            builder.Property(p => p.Phone).IsRequired();
            builder.Property(p => p.Site).IsRequired(false);
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.IsPublish).IsRequired();
            builder.HasMany(p => p.RepresentativesTranslates).WithOne(p => p.Representatives).HasForeignKey(p => p.RepresentativeId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
