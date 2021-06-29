using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.CallBacks;

namespace TSTB.DAL.Data.Configuration.CallBacksConfiguration
{
    public class CallBackTranslateConfiguration : IEntityTypeConfiguration<CallBackTranslate>
    {
        public void Configure(EntityTypeBuilder<CallBackTranslate> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.CallBackId).IsRequired();
            builder.Property(p => p.Address).IsRequired();
            builder.Property(p => p.LanguageCulture).IsRequired(false);
        }
    }
}
