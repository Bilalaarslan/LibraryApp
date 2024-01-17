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
    public class ProcessRepository : BaseRepository<Process>, IProcessRepository
    {
        public ProcessRepository(LibraryAppDbContext libraryAppDbContext) : base(libraryAppDbContext)
        {
        }
    }
}
