using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.User;

namespace TSTB.DAL.Data.Configuration.ApplicationUserConfiguration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(p => p.FirstName).IsRequired(false);
            builder.Property(p => p.LastName).IsRequired(false);
            builder.Property(p => p.SecondName).IsRequired(false);
            builder.Property(p => p.DateBirthday).IsRequired(false);
            builder.Property(p => p.Photo).IsRequired(false);
            builder.Property(p => p.OrganizationId).IsRequired(false);
            builder.HasOne(p => p.Organization).WithOne(p => p.ApplicationUser).HasForeignKey<Organization>(p => p.ApplicationUserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.PaymentCharity).WithOne(p => p.ApplicationUser).HasForeignKey(p => p.ApplicationtUserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.Declaration).WithOne(p => p.ApplicationUser).HasForeignKey(p => p.ApplicationUserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.Payment).WithOne(p => p.ApplicationUser).HasForeignKey(p => p.ApplicationUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
