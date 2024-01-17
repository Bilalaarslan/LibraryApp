using LibraryApp.Application.Concracts.Persistance;
using LibraryApp.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private LibraryAppDbContext _libraryAppDbContext;

        /* Private set; ifadesi, özelliklerin sadece sınıf içinde ayarlanabilir olmasını sağlarken, dışarıdan erişilemez hale getirir. Bu, özelliklerin yalnızca sınıf içindeki diğer metotlar tarafından değer ataması yapılabilmesini sağlar.

         Aşağıdaki kod örneğinde, private set; ifadesi get ve set erişim belirteçleriyle birlikte kullanılmıştır. Bu durumda, özellikler sadece okunabilir (get erişim belirteci) ve sınıf içindeki yapıcı metotta (UnitOfWork) değer ataması yapılabilir (set erişim belirteci). Bu nedenle, xYazarRepository, xKitapRepository, xOgrenciRepository, xTurRepository, xIslemRepository ve xSinifRepository özelliklerine sadece UnitOfWork sınıfının içinde erişilebilir ve değer ataması yapılabilir.

        Bu yapı, genellikle bir sınıfın dışarıya açık bir arabirim sağlarken, iç durumunun korunmasını ve sınıfın iç kontrolünün sağlanmasını amaçlayan bir kapsülleme prensibini uygular. private set; ifadesi, sınıfın dışarıdan özelliklerin değerlerini doğrudan değiştirmesini engeller ve sınıfın kontrolü altında olmasını sağlar.*/
        public IWriterRepository WriterRepository { get; private set; }

        public IStudentRepository StudentRepository { get; private set; }
        public IProcessRepository ProcessRepository { get; private set; }

        public IMyClassRepository MyClassRepository { get; private set; }

        public ICategoryRepository CategoryRepository { get; private set; }

        public IBookRepository BookRepository { get; private set; }

        public UnitOfWork(LibraryAppDbContext libraryAppDbContext)
        {
            _libraryAppDbContext = libraryAppDbContext;

            WriterRepository = new WriterRepository(_libraryAppDbContext);
            StudentRepository= new StudentRepository(_libraryAppDbContext);
            ProcessRepository= new ProcessRepository(_libraryAppDbContext);
            MyClassRepository= new MyClassRepository(_libraryAppDbContext);
            CategoryRepository= new CategoryRepository(_libraryAppDbContext);
            BookRepository= new BookRepository(_libraryAppDbContext);
        }
        public void Save()
        {
            _libraryAppDbContext.SaveChanges();
        }
    }
}
