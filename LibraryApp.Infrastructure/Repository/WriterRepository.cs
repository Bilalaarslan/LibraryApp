using LibraryApp.Application.Concracts.Persistance;
using LibraryApp.Entity;
using LibraryApp.Entity.ViewsModels;
using LibraryApp.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Repository
{
    public class WriterRepository : BaseRepository<Writer>, IWriterRepository
    {
        //Depenceny İnjection işlemi yapıldı.
        private LibraryAppDbContext _libraryDbContext;
        public WriterRepository(LibraryAppDbContext libraryAppDbContext) : base(libraryAppDbContext)
        {
            _libraryDbContext = libraryAppDbContext;
        }

        public IEnumerable<WriterDetailsVM> GetWriterDetails(Guid id)
        {
            IEnumerable<WriterDetailsVM> query = (from wr in _libraryDbContext.Writers
                                                   join bk in _libraryDbContext.Books on wr.Id equals bk.WriterId
                                                   join ct in _libraryDbContext.Categories on bk.CategoryId equals ct.Id
                                                   where wr.Id == id
                                                   select new WriterDetailsVM
                                                   {
                                                       WriterFullName = wr.WriterFullName,
                                                       CategoryName = ct.CategoryName,
                                                       BookName = bk.BookName,
                                                       Point = bk.Point,
                                                       NumberOfPage = bk.NumberOfPage,

                                                   });
            return query;
        }
    }
}
