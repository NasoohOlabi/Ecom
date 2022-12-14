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
    public class CouponRepo : BaseRepo<CouponRepo,Coupon>, ICouponRepo
    {
        public CouponRepo(EComContext db, ILogger<CouponRepo> logger) : base(db,logger)
        {
        }
    }
}
