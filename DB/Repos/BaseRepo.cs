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

        private EComContext _db;
        private DbSet<T> _dbSet;

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
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
