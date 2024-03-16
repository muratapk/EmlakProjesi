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
    public class MusteriRepository : GenericRepository<Musteri>, IMusteriRepository
    {
        public MusteriRepository(ApplicationDbContext db) : base(db)
        {

        }

       
    }
}
