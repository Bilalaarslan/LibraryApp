using LibraryApp.Entity;
using LibraryApp.Entity.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Concracts.Persistance
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        IEnumerable<CategoryDetailsVM> GetCategoryDetails(Guid id);

       
    }
}