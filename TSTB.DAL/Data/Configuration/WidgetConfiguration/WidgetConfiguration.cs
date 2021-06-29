using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.Widget;

namespace TSTB.DAL.Data.Configuration.WidgetConfiguration
{
    class WidgetConfiguration :  IEntityTypeConfiguration<Widget>
    {
        public void Configure(EntityTypeBuilder<Widget> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IsPublish).IsRequired();
            builder.Property(p => p.Logo).IsRequired();
            builder.Property(p => p.Link).IsRequired(false);
            builder.Property(p => p.Order).IsRequired();
            builder.HasMany(p => p.WidgetTranslates).WithOne(p => p.Widget).HasForeignKey(p => p.WidgetID).OnDelete(DeleteBehavior.Cascade);
        }
    

    }
}
