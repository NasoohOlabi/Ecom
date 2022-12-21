using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.IRepos
{
    public interface ICategoryRepo : IBaseRepo<Category>
    {
        public void UpdateAttributeList(long id, IEnumerable<long> attributesIds);
        public void DeleteAttributeList(long id);


    }
}
