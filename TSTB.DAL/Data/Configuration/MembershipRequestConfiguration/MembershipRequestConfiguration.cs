using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.MembershipRequest;

namespace TSTB.DAL.Data.Configuration.MembershipRequestConfiguration
{
    class MembershipRequestConfiguration : IEntityTypeConfiguration<MembershipRequest>
    {
        public void Configure(EntityTypeBuilder<MembershipRequest> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Patent_Ustaw).IsRequired();
            builder.Property(p => p.RegistrUdost_EGRPO).IsRequired();
            builder.Property(p => p.Passport).IsRequired();
            builder.Property(p => p.Declaration_Certificate).IsRequired();
            builder.Property(p => p.EnqueryFrom).IsRequired();
            builder.Property(p => p.PrivateForm).IsRequired();
            builder.Property(p => p.SchoolCertificate).IsRequired();
            builder.Property(p => p.CommandOrder).IsRequired(false);
            builder.Property(p => p.IncomeReport).IsRequired(false);
            builder.Property(p => p.PhoneNumber).IsRequired();
            builder.Property(p => p.MembershipRequestStatus).IsRequired();
        }
    }
}
