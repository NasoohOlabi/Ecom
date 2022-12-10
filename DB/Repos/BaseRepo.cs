using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.IRepos;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace DB.Repos
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {

        protected EComContext _db;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public BaseRepo(EComContext db, ILogger logger)
        {
            _db = db;
            _dbSet = db.Set<T>();
            _logger = logger;
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public void Delete(long id)
        {
            var entity =  _dbSet.Find(id);
            if (entity != null)
            _dbSet.Remove(entity);
        }

        public async Task<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T>?> DeleteAsync(long id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
                return _dbSet.Remove(entity);
            return null;
        }

        public T? Get(long id)
        {
            return _dbSet.Find(id);
        }

        public ValueTask<T?> GetAsync(long id)
        {
            return _dbSet.FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }
    }
}
