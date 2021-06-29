using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Ip;

namespace TSTB.DAL.Data.Configuration.IpCountryConfiguration
{
    class VisitorsConfiguration : IEntityTypeConfiguration<Visitors>
    {
        public void Configure(EntityTypeBuilder<Visitors> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Ip).IsRequired();
            builder.Property(p => p.VisitDate).IsRequired();
                
        }
    
    }
}
