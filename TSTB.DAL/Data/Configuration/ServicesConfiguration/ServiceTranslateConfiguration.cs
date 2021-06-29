using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Services;

namespace TSTB.DAL.Data.Configuration.ServicesConfiguration
{
    class ServiceTranslateConfiguration : IEntityTypeConfiguration<ServiceTranslate>
    {
        public void Configure(EntityTypeBuilder<ServiceTranslate> builder)
        {
       
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ServiceId).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired(false);
            builder.Property(p => p.LanguageCulture).IsRequired();
        }
    }
}
