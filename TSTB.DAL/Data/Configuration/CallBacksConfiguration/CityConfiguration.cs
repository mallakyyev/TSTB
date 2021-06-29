using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.CallBacks;

namespace TSTB.DAL.Data.Configuration.CallBacksConfiguration
{
    class CityConfiguration : IEntityTypeConfiguration<Cities>
    {
        public void Configure(EntityTypeBuilder<Cities> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.CallBacks).WithOne(p => p.Cities).HasForeignKey(p => p.CityId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.CitiesTranslates).WithOne(p => p.Cities).HasForeignKey(p => p.CityId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
