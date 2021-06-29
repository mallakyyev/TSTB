using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Sayings;

namespace TSTB.DAL.Data.Configuration.SayingsConfiguration
{
    class SayingsConfiguration : IEntityTypeConfiguration<Sayings>
    {
        public void Configure(EntityTypeBuilder<Sayings> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.IsPublish).IsRequired();                      
            builder.HasMany(p => p.SayingsTranslates).WithOne(p => p.Sayings).HasForeignKey(p => p.SayingsId).OnDelete(DeleteBehavior.Cascade);

        }
    
    }
}
