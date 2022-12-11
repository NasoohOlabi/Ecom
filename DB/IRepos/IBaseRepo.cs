using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DB.IRepos
{
    public interface IBaseRepo<T> where T : class
    {
        //T? Get(long id);
        //ValueTask<T?> GetAsync(long id);

        //Task<List<T>> GetAllAsync();

        //void Delete(long id);
        //public Task<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T>?> DeleteAsync(long id);
        //void Add(T item);

        //void Update(T item);
        //IEnumerable<T> GetAll();

        public IEnumerable<T> Get(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "");

        public Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "");

        public T? GetByID(long id);

        public Task<T?> GetByIDAsync(long id);

        public void Insert(T entity);

        public Task InsertAsync(T entity);

        public void Delete(long id);

        public Task DeleteAsync(long id);

        public void Delete(T entityToDelete);

        public void Update(T entityToUpdate);
    }
}
