using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Email;

namespace TSTB.DAL.Data.Configuration.EmailConfiguration
{
    class SubscribersConfiguration : IEntityTypeConfiguration<Subscribers>
    {
        public void Configure(EntityTypeBuilder<Subscribers> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Email).IsRequired();                       
        }
    }
}
