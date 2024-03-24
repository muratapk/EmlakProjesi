using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IGenericServiceRepository<T> where T : class
    {
        //oluşturulacak methodlar
        //listeleme ekleme silme düzeltme tek veri çekme çoklu veri
        IEnumerable<T> TGetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        //Expression içersine alınan fonksiyon sonucu true veya false içinde filter boş ise bunu null kabulet içinde string yok ise bunu includeProperties boş olarak kabul et
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        //filter olacak string boş ise includeProperties boş kabul edebilirsin
        void TAdd(T entity);
        //ekleme işlemi 
        void TUpdate(T entity);
        //düzeltme işlemin geçerleştir
        void TDelete(T entity);
        //silme işlemin gerçekleştir
        void Save();
    }
}
