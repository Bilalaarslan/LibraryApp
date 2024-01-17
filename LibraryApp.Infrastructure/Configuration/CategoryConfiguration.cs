using LibraryApp.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Configuration
{
    //IEntityTypeConfigurationdan inherit almalı.ayrıca bu clasların amacı modellerin databasedaki biçimlerini ve ilişkileri belirlemek.
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x=>x.CategoryName).IsRequired().HasMaxLength(40);
        }
    }
}
