using DB.IRepos;
using DB.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repos
{
    public class ShippingRepo : BaseRepo<ShippingRepo, Shipping>, IShippingRepo
    {
        public ShippingRepo(EComContext db, ILogger<ShippingRepo> logger) : base(db, logger)
        {
        }
    }
}

