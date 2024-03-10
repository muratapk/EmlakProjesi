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
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;
        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
            dbset = _db.Set<T>();
        }


        public void Add(T entity)
        {
            dbset.Add(entity);
            
        }

        public void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
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

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
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
            return query.ToList();
        }

       

        public void Update(T entity)
        {
            dbset.Update(entity);
        }
    }
}
