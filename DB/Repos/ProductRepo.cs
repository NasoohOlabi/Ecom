using DB.IRepos;
using DB.Models;
using DB.UOW;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repos
{
    public class ProductRepo : BaseRepo<ProductRepo,Product>, IProductRepo
    {
        public ProductRepo(EComContext db, ILogger<ProductRepo> logger) : base(db,logger)
        {
        }

        public void UpdateRating(long id, long count, long sum)
        {
            try
            {
                var prod = _dbSet.First(x => x.Id == id);
                prod.RatingSum = sum;
                prod.RatingCount = count;
            }
            catch (InvalidOperationException)
            {
                string message = $"A Product with id {id} Was Deleted before Rating Was Updated to count {count} and sum {sum}";
                if (_logger != null)
                    _logger.LogDebug(message);
            }
        }
    }
}
