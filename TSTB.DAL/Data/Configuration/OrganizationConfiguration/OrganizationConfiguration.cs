using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.User;

namespace TSTB.DAL.Data.Configuration.OrganizationConfiguration
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NameOrganization).IsRequired(false);
            builder.Property(p => p.Activity).IsRequired();
            builder.Property(p => p.TaxCode).IsRequired();
            builder.Property(p => p.AddressOrganization).IsRequired();
            builder.Property(p => p.PhoneOrganization).IsRequired();
            builder.Property(p => p.MembershipDate).IsRequired();
            builder.Property(p => p.Sex).IsRequired();
            builder.Property(p => p.CityId).IsRequired();
            builder.Property(p => p.BirthPlace).IsRequired();
            builder.Property(p => p.PassportSN).IsRequired();
            builder.Property(p => p.IssuedBy).IsRequired();
            builder.Property(p => p.IssuedDate).IsRequired();
            builder.Property(p => p.PlaceRegistration).IsRequired();
            builder.Property(p => p.ApplicationUserId).IsRequired();
            builder.HasOne(p => p.Cities).WithMany(p => p.Organizations).HasForeignKey(p => p.CityId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
