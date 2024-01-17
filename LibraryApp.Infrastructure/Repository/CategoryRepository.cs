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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private LibraryAppDbContext _libraryAppDbContext;

        public CategoryRepository(LibraryAppDbContext libraryAppDbContext) : base(libraryAppDbContext)
        {
            _libraryAppDbContext = libraryAppDbContext;
        }

        public IEnumerable<CategoryDetailsVM> GetCategoryDetails(Guid id)
        {
            IEnumerable<CategoryDetailsVM> query = (from ct in _libraryAppDbContext.Categories
                                                    join bk in _libraryAppDbContext.Books on ct.Id equals bk.CategoryId
                                                    join wr in _libraryAppDbContext.Writers on bk.WriterId equals wr.Id
                                                    where ct.Id == id
                                                    select new CategoryDetailsVM
                                                    {
                                                        CategoryName = ct.CategoryName,
                                                        BookName = bk.BookName,
                                                        Point = bk.Point,
                                                        WriterFullName = wr.WriterFullName,

                                                    }).ToList();


            //Burada neden Tolist kullanmak zorundayım eğer list olarak cshtml de kullanacaksam. Ayrıca query değişkeni her iki durumda da Iqueryable tipinde kalmakta neden?



            return query;
        }
    }
}
