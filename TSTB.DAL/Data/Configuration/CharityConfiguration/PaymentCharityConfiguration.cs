using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Charity;

namespace TSTB.DAL.Data.Configuration.CharityConfiguration
{
    class PaymentCharityConfiguration : IEntityTypeConfiguration<PaymentCharity>
    {
        public void Configure(EntityTypeBuilder<PaymentCharity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CharityId).IsRequired();
            builder.Property(p => p.Description).IsRequired(false);
            builder.Property(p => p.ApplicationtUserId).IsRequired();
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.PaymentDate).IsRequired();
            builder.Property(p => p.PaymentStatus).IsRequired();
            builder.Property(p => p.BankPaymentId).IsRequired(false);
            builder.Property(p => p.PaymentNumber).IsRequired();
        }   
    
    }
}
