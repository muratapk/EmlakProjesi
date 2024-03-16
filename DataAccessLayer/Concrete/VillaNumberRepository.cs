using DataAccessLayer.Abstract;
using DataAccessLayer.Data;
using EntityLayer.Entire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
   public class VillaNumberRepository : GenericRepository<VillaNumber>, IVillaNumber
    {
        public VillaNumberRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
