using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Partners;

namespace TSTB.DAL.Data.Configuration.PartnersConfiguration
{
    class PartnerTranslateConfiguration : IEntityTypeConfiguration<PartnerTranslate>
    {
        public void Configure(EntityTypeBuilder<PartnerTranslate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.PartnerId).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.LanguageCulture).IsRequired();
         }
    }
}
