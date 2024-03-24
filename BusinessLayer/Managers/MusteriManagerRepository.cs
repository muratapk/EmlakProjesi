using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Entire;
namespace BusinessLayer.Managers
{
    public class MusteriManagerRepository : GenericManagerRepository<Musteri>
    {
        public MusteriManagerRepository(IGenericRepository<Musteri> repository) : base(repository)
        {
        }
    }
}
