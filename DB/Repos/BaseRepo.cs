using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.IRepos;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Repos
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {

        protected EComContext _db;
        private readonly DbSet<T> _dbSet;

        public BaseRepo(EComContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public void Delete(int id)
        {
            var entity =  _dbSet.Find(id);
            if (entity != null)
            _dbSet.Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            _dbSet.Remove(entity);
        }

        public T? Get(int id)
        {
            return _dbSet.Find(id);
        }

        public ValueTask<T?> GetAsync(int id)
        {
            return _dbSet.FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }
    }
}
