using EntityLayer.Entire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericRepository<T>where T:class
    {
        //oluşturulacak methodlar
        //listeleme ekleme silme düzeltme tek veri çekme çoklu veri
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        //Expression içersine alınan fonksiyon sonucu true veya false içinde filter boş ise bunu null kabulet içinde string yok ise bunu includeProperties boş olarak kabul et
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        //filter olacak string boş ise includeProperties boş kabul edebilirsin
        void Add(T entity);
        //ekleme işlemi 
        void Update(T entity);
        //düzeltme işlemin geçerleştir
        void Delete(T entity);
        //silme işlemin gerçekleştir
        
    }
}
