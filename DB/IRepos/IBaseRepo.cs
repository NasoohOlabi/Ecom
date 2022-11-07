using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.IRepos
{
    public interface IBaseRepo<T> where T : class
    {
        T? Get(int id);
        ValueTask<T?> GetAsync(int id);

        void Delete(int id);
        Task DeleteAsync(int id);
        void Add(T item);

        void Update(T item);
        IEnumerable<T> GetAll();
    }
}
