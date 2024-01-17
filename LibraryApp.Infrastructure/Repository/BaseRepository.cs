using LibraryApp.Application.Concracts.Persistance;
using LibraryApp.Entity;
using LibraryApp.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Repository
{
    /*Set<T>() ifadesi, DbSet<T> nesnesini elde etmek için kullanılır. DbSet<T>, Entity Framework Core tarafından sağlanan bir sınıftır ve veri tabanında belirli bir varlık türü için CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştirmek için kullanılır.

      BaseRepository<T> sınıfının yapıcı metodunda _kutuphaneDbContext bağımlılığından gelen bir veritabanı bağlamı alınır. _kutuphaneDbContext.Set<T>() ifadesi, bu veritabanı bağlamı üzerinde T türündeki varlık için bir DbSet nesnesi elde etmeyi sağlar.

      DbSet<T>, ilgili veri tabanı bağlamı üzerindeki varlık türüne bağlı bir koleksiyonu temsil eder. Bu koleksiyon, ilgili varlık türüne ait verileri içerir ve veri tabanı işlemlerini gerçekleştirmek için kullanılır. Örneğin, koleksiyon üzerinde sorgulamalar yapılabilir, yeni varlık nesneleri eklenebilir, mevcut varlık nesneleri güncellenebilir veya silinebilir.

      this.dbSet = _kutuphaneDbContext.Set<T>(); ifadesi, BaseRepository<T> sınıfının dbSet alanını _kutuphaneDbContext bağımlılığından alınan DbSet<T> nesnesi ile ilişkilendirir. Bu sayede, BaseRepository<T> sınıfının alt sınıfları, dbSet alanını kullanarak ilgili varlık türü için veri tabanı işlemlerini gerçekleştirebilir. */
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly LibraryAppDbContext _libraryAppDbContext;

        // internal: Tanımlandığı proje (assembly) içinden erişilebilir. Yani, aynı derleme içerisindeki diğer sınıflar bu üyelere erişebilir. Ancak, diğer projelerden erişim engellenir. Bu erişim belirleyicisi, aynı projede paylaşılan ve diğer bileşenlerle iletişim kurması gereken üyeleri tanımlamak için kullanılır.Neden internal yapıldı?

        //        Internal
        //Kendi projesi içerisinde public, farklı bir projeden/dışarıdan çağırılmak istenildiğinde ise private özelliklerini taşır.Yani aynı Assembly (dll) üzerinde istediğiniz şekilde kullanabilirsiniz ancak dışarıdan (farklı bir projeden) çağıramazsınız.

//        Protected
//         Bir nesne protected olarak tanımlandığında yalnızca bulunduğu class üzerinde ve bu class ı miras alan(bu class’tan             türetilmiş) classlar üzerinden çağırılabilir.

        //Private
        //Bir nesne private olarak tanımlandığında sadece kendi kod bloğu içerisinden çağrılabilir.Güvenlik nedeniyle dışarıya kesinlikle açmamamız gereken nesnelerde kullanılır.

        private DbSet<T> dbSet;

        
        
        // Yapıcı metodu neden kullanıyoruz?
        public BaseRepository(LibraryAppDbContext libraryAppDbContext)
        {
            _libraryAppDbContext = libraryAppDbContext;
            this.dbSet = _libraryAppDbContext.Set<T>();

            //dbSet yaratılmasaydı aşağıdaki gibi yapacaktık! dbSet mantığı budur.
            //_dbContext.Set<ReservationService>().Add(reservationService);
            //_dbContext.SaveChanges();
        }

        public async Task Addasync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

      
        //Nasıl ve neden yapıldı?
        public void DeleteRange(IEnumerable<T> entities)
        {
             dbSet.RemoveRange(entities);
        }

        

        //IBaseden geliyor ama asenkron yapamıyorum.Yerine yukarıdakini kullandım.
        public T Find(Guid Id)
        {
           return dbSet.Find(Id);
        }

        //Nasıl ve neden yapıldı?
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query;
        }
        //Nasıl ve neden yapıldı?
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        
       

        public List<T> GetAll()
        {
            var query = dbSet.ToList();
            return query;
        }

        T IBaseRepository<T>.Update(T entity)
        {
            dbSet.Update(entity);
            return entity;
        }

       
        
    }
}
