using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.IRepos
{
    public interface IBaseRepo<T> where T : class
    {
        T? Get(long id);
        ValueTask<T?> GetAsync(long id);

        Task<List<T>> GetAllAsync();

        void Delete(long id);
        public Task<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T>?> DeleteAsync(long id);
        void Add(T item);

        void Update(T item);
        IEnumerable<T> GetAll();
    }
}
