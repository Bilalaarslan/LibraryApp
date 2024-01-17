using LibraryApp.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Configuration
{ /* Modellerimizin(Entity classlar)Configuration classlarının IEntityTypeConfiguration Interfacesinden(.Net Hazır kutuphanesinden) kalıtım alma amacı IEntityTypeConfiguration Interfacesinin kendi içinde bizim */
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x=>x.BookName).IsRequired().HasMaxLength(700);
        }

        
    }
}
