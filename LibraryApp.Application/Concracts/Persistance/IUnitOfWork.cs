using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Concracts.Persistance
{
    /* 1.Bu kod bloğu, birim ofisi (unit of work) tasarım desenini uygulayan bir arayüzü tanımlamaktadır. Birim ofisi tasarım deseni, bir grup ilgili işlemi tek bir işlem olarak ele almayı sağlar.
       2.Bu arayüz, çeşitli veri kaynağı işlemlerini yönetmek ve işlemleri gruplamak için kullanılabilir. Çoğunlukla ORM (Object-Relational Mapping) gibi bir veritabanı erişim teknolojisiyle birlikte kullanılır. Her bir Repository nesnesi, veri kaynağındaki belirli bir varlık türü (yazar, kitap, öğrenci vb.) ile ilgili işlemleri gerçekleştirir. Birim ofisine ait Save metodu ise yapılan tüm değişiklikleri veritabanına kaydetmek için kullanılır.*/
    public interface IUnitOfWork
    {
        IWriterRepository WriterRepository { get; }
        IStudentRepository StudentRepository { get; }
        IProcessRepository ProcessRepository { get; }

        IMyClassRepository MyClassRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        IBookRepository BookRepository { get; }

        void Save();

    }
}
