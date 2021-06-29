using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Partners;

namespace TSTB.DAL.Data.Configuration.PartnersConfiguration
{
    class PartnerDataTranslateConfiguration : IEntityTypeConfiguration<PartnersDataTranslate>
    {
        public void Configure(EntityTypeBuilder<PartnersDataTranslate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.PartnersDataId).IsRequired();
            builder.Property(p => p.Description).IsRequired(false);
            builder.Property(p => p.LanguageCulture).IsRequired();
         }
    }
}
