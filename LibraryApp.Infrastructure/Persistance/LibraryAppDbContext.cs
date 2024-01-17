using LibraryApp.Entity;
using LibraryApp.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Persistance
{
    public class LibraryAppDbContext:DbContext
    {
        // Bu kapmanın Classlarının görülebilmesi için, bu katmanın dependenciesinden Entity katmanına referans verilmesi gereklidir.
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<MyClass> MyClasses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        public LibraryAppDbContext(DbContextOptions<LibraryAppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WriterConfiguration())
                .ApplyConfiguration(new StudentConfiguration())
                .ApplyConfiguration(new ProcessConfiguration())
                .ApplyConfiguration(new MyClassConfiguration())
                .ApplyConfiguration(new CategoryConfiguration())
                .ApplyConfiguration(new BookConfiguration());

            base.OnModelCreating(modelBuilder);

        }
    }


}
