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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x=>x.StudentName).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.StudentSurname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DateOfAdding).IsRequired();
            builder.Property(x => x.DateOfUpdate).IsRequired();
            builder.Property(x => x.DateOfBirthStudent).IsRequired();
        }
    }
}
