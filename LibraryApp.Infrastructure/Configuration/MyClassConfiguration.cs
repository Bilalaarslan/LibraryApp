using LibraryApp.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Configuration
{
    public class MyClassConfiguration : IEntityTypeConfiguration<MyClass>
    {
        public void Configure(EntityTypeBuilder<MyClass> builder)
        {
            builder.Property(x=>x.ClassName).IsRequired().HasMaxLength(50);
        }
    }
}
