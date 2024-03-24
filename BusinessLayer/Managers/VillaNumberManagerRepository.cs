using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Entire;
namespace BusinessLayer.Managers
{
    public class VillaNumberManagerRepository : GenericManagerRepository<VillaNumber>
    {
        public VillaNumberManagerRepository(IGenericRepository<VillaNumber> repository) : base(repository)
        {
        }
    }
}
