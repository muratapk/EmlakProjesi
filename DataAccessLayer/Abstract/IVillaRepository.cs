using EntityLayer.Entire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IVillaRepository
    {
        //oluşturulacak methodlar
        //listeleme ekleme silme düzeltme tek veri çekme çoklu veri
        IEnumerable<Villa> GetAll(Expression<Func<Villa,bool>>?filter=null,string? includeProperties=null);
        //Expression içersine alınan fonksiyon sonucu true veya false içinde filter boş ise bunu null kabulet içinde string yok ise bunu includeProperties boş olarak kabul et
         Villa Get(Expression<Func<Villa, bool>>filter , string? includeProperties = null);
        //filter olacak string boş ise includeProperties boş kabul edebilirsin
        void Add(Villa villa);
        void Update(Villa villa);
        void Delete(Villa villa);
        void Save();

    }
}
