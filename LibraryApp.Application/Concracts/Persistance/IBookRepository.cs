using LibraryApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Concracts.Persistance
{
    /* IBookRepository, IBaseRepositoryden(Book tipinde nesnelerle çalışacak olan) kalıtım alarak, kendi tipinde yani "Book" ( IBaseRepository nin T tipi generic yapı olması sayesinde) parametrelendirilmiş CRUD metodları (1.Create 2.Read 3.Update 4. Delete) ve tüm modellerimizde ihtiyaç olabilecek(base olmasından dolayı) kendi yarattığımız metodlarımızı, IBookRepository Interfacesine aktarmış olur. Application(Business Logic Layer) katmanında oluşturulan bu InterfaceRepositoryler alanı, projemizde statik(kalıcı) kalarak InfraStructure(Data Access Layer) katmanında istenilen her ORM aracına (içindeki repository classlarına) kalıtım vererek temel Repository iskeletimizi kalıcı, bakımı kolay ve sürdürlebilir kılar. */

    public interface IBookRepository : IBaseRepository<Book>
    {
        
    }
}
