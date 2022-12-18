using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.IRepos
{
    public interface IProductRepo : IBaseRepo<Product>
    {
        public void UpdateRating(long id,long count, long sum);
    void UpdateSpecificationsList(Repos.EditProductSpecificationsViewModel eProductSpecifications);
  }
}
