﻿using DB.IRepos;
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
    public class OrderRepo : BaseRepo<OrderRepo,Order>, IOrderRepo
    {
        public OrderRepo(EComContext db, ILogger<OrderRepo> logger ) : base(db,logger)
        {
        }
    }
}
