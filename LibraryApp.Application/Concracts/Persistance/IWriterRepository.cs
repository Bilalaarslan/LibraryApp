using LibraryApp.Entity;
using LibraryApp.Entity.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Concracts.Persistance
{
    public interface IWriterRepository : IBaseRepository<Writer>
    {
        // Writerse ait bir işlem olmasından dıları bu metodu WriterRepository içerisinde oluşturduk.
        IEnumerable<WriterDetailsVM> GetWriterDetails(Guid id);
    }
}
