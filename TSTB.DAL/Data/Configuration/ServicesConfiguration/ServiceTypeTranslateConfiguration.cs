using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Services;

namespace TSTB.DAL.Data.Configuration.ServicesConfiguration
{
    class ServiceTypeTranslateConfiguration : IEntityTypeConfiguration<ServiceTypeTranslate>
    {
        public void Configure(EntityTypeBuilder<ServiceTypeTranslate> builder)
        {
     
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ServiceTypeId).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired(false);
            builder.Property(p => p.LanguageCulture).IsRequired();
        }
    }
}
