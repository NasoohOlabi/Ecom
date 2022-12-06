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
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {

        private readonly ILogger<ProductRepo> _logger;



        public OrderRepo(EComContext db, ILogger<ProductRepo> logger) : base(db)
        {
            _logger = logger;
        }

        
    }
}
