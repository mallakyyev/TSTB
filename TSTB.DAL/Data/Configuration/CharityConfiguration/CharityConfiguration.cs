using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Charity;

namespace TSTB.DAL.Data.Configuration.CharityConfiguration
{
    public class CharityConfiguration : IEntityTypeConfiguration<Charity>
    {
        public void Configure(EntityTypeBuilder<Charity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Image).IsRequired(false);
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.IsPublish).IsRequired();
            builder.HasMany(p => p.PaymentCharity).WithOne(p => p.Charity).HasForeignKey(p => p.CharityId).OnDelete(DeleteBehavior.Restrict);
        }    
    }
}
