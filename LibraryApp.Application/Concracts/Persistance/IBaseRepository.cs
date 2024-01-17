using LibraryApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Concracts.Persistance
{
    public interface IBaseRepository<T> where T : BaseEntity

        /*  1."where T : BaseEntity" anlamı sadece BaseEntityden kalıtım alan (yani Base Entityden türeyen) classlar kullanılabilir T olarak demek,
            2.IBaseRepositorynin T generic tipte olmasının nedeni, bir IBaseRepository olarak kendinden kalıtım alan repository claslarının içinde kalıtım alınan IBaseRepositorinin kendi metodları (içeriğini) uygulanırken kalıtım alan clas tipi geçerli olmasını sağlamaktır. Yani bu Interface T türündeki nesnelerle çalışacaktır.Bu T türüde bu IBaseRepositoriyi kalıtım alan clasın türü olacaktır.
            3. Generic tip (T tipi) Base Interface ve Classlarda kullanım gerektirmektedir. */
    {
        public Task Addasync(T entity);// CRUD un C si(Creat) ifade eder.

        public T Update(T entity);

        void Remove(T entity);

        void DeleteRange(IEnumerable<T> entities);


        /* Bu ifade, bir IEnumerable<T> döndüren ve filtreleme işlemi için bir Expression<Func<T, bool>> parametresi alan bir metodu tanımlar. İşlevsel olarak, bu metod T türündeki nesnelerin bir koleksiyonunu döndürürken, bir filtre kullanarak belirli bir koşulu karşılayan nesneleri seçmeyi sağlar.

Aşağıda ifadenin detaylarını açıklayalım:

IEnumerable<T>: Bu geri dönüş türü, T türündeki nesnelerin bir koleksiyonunu temsil eder. IEnumerable<T>, koleksiyondaki nesnelere sıralı erişim sağlamak için kullanılır. Bu, genellikle bir dizi, liste veya diğer koleksiyonların üzerinde döngü veya LINQ sorguları kullanarak işlemler yapmak için kullanılır.

GetAll: Metodun adı, genellikle bir veri kaynağından tüm nesneleri almak için kullanılan bir ad olarak düşünülebilir. Ancak, bu ifadede belirtilen bir veri kaynağı yoktur, bu nedenle gerçek uygulama bağlamına bağlı olarak farklı bir anlama gelebilir.

Expression<Func<T, bool>>? filter=null: Bu parametre, T türündeki nesnelerin filtrelenmesi için bir lambda ifadesini (Expression<Func<T, bool>>) kabul eder. Lambda ifadesi, her T nesnesinin üzerinde değerlendirildiğinde true veya false dönen bir koşul ifadesini temsil eder. Bu sayede, yalnızca belirli bir koşulu sağlayan nesneleri döndürebilirsiniz. Parametre, null değeri de alabilir, bu durumda herhangi bir filtreleme uygulanmadığını gösterir.*/

        //IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null); eskisi

        List<T> GetAll();
        

        /* Bu ifade, bir T türündeki nesnelerin koleksiyonunda belirli bir koşulu sağlayan ilk nesneyi veya varsayılan değeri (default(T)) döndüren bir metodu tanımlar.

Aşağıda ifadenin detaylarını açıklayalım:

T: Bu, döndürülen nesnenin türünü temsil eder. Örneğin, T yerine Product yazarsak, metot bir Product nesnesi döndürecektir.

GetFirstOrDefault: Metodun adı, bir koleksiyondaki nesnelerden belirli bir koşulu sağlayan ilk nesneyi döndürmek için kullanılan bir ad olarak düşünülebilir.

Expression<Func<T, bool>> filter: Bu parametre, T türündeki nesnelerin filtrelenmesi için bir lambda ifadesini (Expression<Func<T, bool>>) kabul eder. Lambda ifadesi, her T nesnesinin üzerinde değerlendirildiğinde true veya false dönen bir koşul ifadesini temsil eder. Bu sayede, belirli bir koşulu sağlayan nesneyi bulmak için filtreleme yapabilirsiniz.*/

        T GetFirstOrDefault(Expression<Func<T, bool>> filter);

         T Find(Guid Id);

        


    }
}
