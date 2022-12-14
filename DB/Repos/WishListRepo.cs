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
    public class WishListRepo : BaseRepo<WishList>, IWishListRepo
    {
        public WishListRepo(EComContext db, ILogger<WishListRepo> logger) : base(db, logger) { }

    }
}
