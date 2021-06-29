using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Email;

namespace TSTB.DAL.Data.Configuration.EmailConfiguration
{
    class EmailsConfiguration : IEntityTypeConfiguration<Emails>
    {
        public void Configure(EntityTypeBuilder<Emails> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Subject).IsRequired();
            builder.Property(p => p.Message).IsRequired();
            builder.Property(p => p.SendedToEntrepreneur).IsRequired();
            builder.Property(p => p.SendedToOrganization).IsRequired();
            builder.Property(p => p.SendedToSubscribers).IsRequired();
        }
    }
}
