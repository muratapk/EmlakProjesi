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
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _db;

        public UnitofWork(ApplicationDbContext db)
        {
            _db = db;
            VillaNumber = new VillaNumberRepository(_db);
            Villa = new VillaRepository(_db);
            Musteri = new MusteriRepository(_db);
            //oluşturmuş repositorylerinin içeresine db context göneriyor
        }

        public IVillaNumber VillaNumber { get; private set; }

        public IVillaRepository Villa { get; private set; }

        public IMusteriRepository Musteri { get; private set; }
    }
}
