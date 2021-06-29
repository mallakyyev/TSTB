using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.NewsPapers;

namespace TSTB.DAL.Data.Configuration.NewsPapersConfiguration
{
    class NewsPaperFilesConfiguration : IEntityTypeConfiguration<NewsPaperFiles>
    {
        public void Configure(EntityTypeBuilder<NewsPaperFiles> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NewsPaperDataId).IsRequired();
            builder.Property(p => p.Image).IsRequired();
        }
    }
}
