using DataAccessLayer.Abstract;
using DataAccessLayer.Data;
using EntityLayer.Entire;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class VillaRepository : IVillaRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public void Add(Villa entity)
        {
            _db.Add(entity);
        }

        public void Delete(Villa entity)
        {
            _db.Remove(entity);
        }

        public Villa Get(Expression<Func<Villa, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Villa> query = _db.Set<Villa>();
            //sorgul olarak çekilecek tabloyu Set metodu ile Iquery yapısındaki
            //query dosyasına ata
            if (filter != null)
            {
                query = query.Where(filter);
                //Where(x=>x.Id==id)
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<Villa> GetAll(Expression<Func<Villa, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<Villa> query = _db.Set<Villa>();
            //sorgul olarak çekilecek tabloyu Set metodu ile Iquery yapısındaki
            //query dosyasına ata
            if(filter!=null)
            {
                query = query.Where(filter);
                //Where(x=>x.Id==id)
            }
            if(!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var includeProp in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Villa entity)
        {
            _db.Update(entity);
        }
    }
}
