using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Billing;

namespace TSTB.DAL.Data.Configuration.BillingConfiguration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Language).IsRequired(false);
            builder.Property(p => p.CurrencyCode).IsRequired(false);
            builder.Property(p => p.PageView).IsRequired(false);
            builder.Property(p => p.Description).IsRequired(false);
            builder.Property(p => p.OrderNumber).IsRequired(false);
            builder.Property(p => p.BankOrderId).IsRequired(false);
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.StatusPayment).IsRequired(false);
            builder.Property(p => p.DatePayment).IsRequired(false);
            builder.Property(p => p.PaymentCreatedDate).IsRequired(true);
            builder.Property(p => p.DeclarationId).IsRequired(false);
            builder.Property(p => p.ApplicationUserId).IsRequired(true);
            builder.HasOne(p => p.Declaration).WithOne(p => p.Payment).HasForeignKey<Declaration>(p => p.PaymentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
