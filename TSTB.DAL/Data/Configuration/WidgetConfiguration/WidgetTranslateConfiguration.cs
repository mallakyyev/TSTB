using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Widget;

namespace TSTB.DAL.Data.Configuration.WidgetConfiguration
{
    class WidgetTranslateConfiguration : IEntityTypeConfiguration<WidgetTranslate>
    {
        public void Configure(EntityTypeBuilder<WidgetTranslate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.WidgetID).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.LanguageCulture).IsRequired();
            builder.Property(p => p.Footer).IsRequired();
        }
    }
}
