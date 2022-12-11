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
    public class ShippingRepo : BaseRepo<Shipping>, IShippingRepo
    {
        public ShippingRepo(EComContext db, ILogger logger) : base(db, logger) { }

    }
}
