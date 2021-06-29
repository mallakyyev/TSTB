using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.NewsPapers;

namespace TSTB.DAL.Data.Configuration.NewsPapersConfiguration
{
    class NewsPapersDataConfiguration : IEntityTypeConfiguration<NewsPaperData>
    {
        public void Configure(EntityTypeBuilder<NewsPaperData> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NewsPaperId).IsRequired();
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p => p.DataOfPublish).IsRequired();
            builder.HasMany(p => p.NewsPaperFiles).WithOne(p => p.NewsPaperData).HasForeignKey(p => p.NewsPaperDataId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
