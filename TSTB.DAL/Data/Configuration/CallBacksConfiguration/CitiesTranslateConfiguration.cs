using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.CallBacks;

namespace TSTB.DAL.Data.Configuration.CallBacksConfiguration
{
    class CitiesTranslateConfiguration : IEntityTypeConfiguration<CitiesTranslate>
    {
        public void Configure(EntityTypeBuilder<CitiesTranslate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CityId).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.LanguageCulture).IsRequired();
        }
    }
}
