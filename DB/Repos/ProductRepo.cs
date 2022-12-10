using DB.IRepos;
using DB.Models;
using DB.UOW;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repos
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        public ProductRepo(EComContext db, ILogger logger) : base(db, logger) { }

        public void UpdateRating(long id, long count, long sum)
        {
            try
            {
                var prod = _db.Products.Single(x => x.Id == id);
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
