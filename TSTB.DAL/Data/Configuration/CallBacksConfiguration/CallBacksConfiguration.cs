using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.CallBacks;

namespace TSTB.DAL.Data.Configuration.CallBacksConfiguration
{
    class CallBacksConfiguration : IEntityTypeConfiguration<CallBack>
    {
        public void Configure(EntityTypeBuilder<CallBack> builder)
        {
    
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Image).IsRequired(false);            
            builder.Property(p => p.Phone).IsRequired();
            builder.Property(p => p.Facks).IsRequired(false);
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.StartWeekDate).IsRequired();
            builder.Property(p => p.EndWeekDate).IsRequired();
            builder.Property(p => p.StartTime).IsRequired();
            builder.Property(p => p.EndTime).IsRequired();
            builder.Property(p => p.CityId).IsRequired();
            builder.Property(p => p.IsPublish).IsRequired();
            builder.HasMany(p => p.CallBackTranslates).WithOne(p => p.CallBack).HasForeignKey(p => p.CallBackId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
