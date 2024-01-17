using LibraryApp.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Configuration
{
    public class WriterConfiguration : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> builder)
        {
            builder.Property(x=>x.WriterName).IsRequired().HasMaxLength(64);
            builder.Property(x => x.WriterSurname).IsRequired().HasMaxLength(64);
            
        }
    }
}
