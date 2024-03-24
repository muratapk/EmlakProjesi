using BusinessLayer.Services;
using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers
{
    public class GenericManagerRepository<T> : IGenericServiceRepository<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        


        public GenericManagerRepository(IGenericRepository<T> repository)
        {
            _repository=repository;
           
        }
        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
           return _repository.Get(filter, includeProperties);
            
        }

        public void Save()
        {
            _repository.Save();
        }

        public void TAdd(T entity)
        {
            _repository.Add(entity);
        }

        public void TDelete(T entity)
        {
            _repository.Delete(entity);
        }

        public IEnumerable<T> TGetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
           return _repository.GetAll(filter, includeProperties);
            
        }

        public void TUpdate(T entity)
        {
            _repository.Update(entity);
        }
    }
}
