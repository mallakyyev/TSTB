using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Billing;

namespace TSTB.DAL.Data.Configuration.BillingConfiguration
{
    class DeclarationConfiguration : IEntityTypeConfiguration<Declaration>
    {
        public void Configure(EntityTypeBuilder<Declaration> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.DateCreateDeclaration).IsRequired();
            builder.Property(p => p.ApplicationUserId).IsRequired();
            builder.Property(p => p.StatusDeclaration).IsRequired();
            builder.Property(p => p.Description).IsRequired(false);
            builder.Property(p => p.YearDeclaration).IsRequired();
            builder.Property(p => p.PaymentId).IsRequired(false);
            builder.HasMany(p => p.DeclarationImages).WithOne(p => p.Declaration).HasForeignKey(p => p.DeclarationId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
