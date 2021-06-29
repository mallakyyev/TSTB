using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Billing;

namespace TSTB.DAL.Data.Configuration.BillingConfiguration
{
    class DeclarationImageConfiguration : IEntityTypeConfiguration<DeclarationImage>    
    {
        public void Configure(EntityTypeBuilder<DeclarationImage> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.DeclarationId).IsRequired();
           
        }
    }
}
