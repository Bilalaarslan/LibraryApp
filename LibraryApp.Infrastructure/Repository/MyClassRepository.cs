using LibraryApp.Application.Concracts.Persistance;
using LibraryApp.Entity;
using LibraryApp.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Repository
{
    public class MyClassRepository : BaseRepository<MyClass>, IMyClassRepository
    {
        public MyClassRepository(LibraryAppDbContext libraryAppDbContext) : base(libraryAppDbContext)
        {
        }
    }
}
