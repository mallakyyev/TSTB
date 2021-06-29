using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Settings;

namespace TSTB.DAL.Data.Configuration.SettingsConfiguration
{
    class SettingsConfiguration : IEntityTypeConfiguration<Settings>
    {
        public void Configure(EntityTypeBuilder<Settings> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Value).IsRequired();
            builder.Property(p => p.Name).IsRequired();
        }
    }
    
    
}
