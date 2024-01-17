using LibraryApp.Application.Concracts.Persistance;
using LibraryApp.Entity;
using LibraryApp.Infrastructure.Persistance;
using LibraryApp.Infrastructure.Repository;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace LibraryApp.Infrastructure.Repository
{
    public class BookRepository:BaseRepository<Book>, IBookRepository
    {
        /* BookRepository sınıfı, BaseRepository<Book> sınıfını kalıtım alarak ve IBookRepository arayüzünü uygulayarak tanımlanmıştır. BaseRepository<Book> sınıfının yapıcısına, libraryAppDbContext parametresi ile bir LibraryAppDbContext nesnesi geçirilerek erişilir. Bu yapılandırıcı metot, BookRepository sınıfının örneklenmesi sırasında çağrılır.

          base(libraryAppDbContext) ifadesi, BookRepository sınıfının üst sınıfına (BaseRepository<Book>) libraryAppDbContext nesnesini ileterek, üst sınıfın yapıcısını çağırmaktadır. Yani, BaseRepository<Book> sınıfının yapıcısı, libraryAppDbContext nesnesini kullanarak ilgili veritabanı bağlantısını yapar veya gerekli başlangıç ayarlarını yapar.

           Bu şekilde, BookRepository sınıfı, BaseRepository<Book> sınıfının işlevselliğini kullanarak, kitaplarla ilgili özel veritabanı işlemlerini gerçekleştirebilir. Örneğin, BaseRepository<Book> sınıfı, CRUD işlemlerini sağlayan genel metodlara sahip olabilir ve BookRepository sınıfı bu metodları kullanarak kitaplarla ilgili veritabanı işlemlerini gerçekleştirebilir.

       */

        private readonly LibraryAppDbContext _libraryAppDbContext;
        public BookRepository(LibraryAppDbContext libraryAppDbContext) : base(libraryAppDbContext)
        {

            _libraryAppDbContext = libraryAppDbContext;

        }
        

        
        
        

     

        

      
    }
}


