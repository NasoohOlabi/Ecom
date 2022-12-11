﻿using DB.IRepos;
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
    public class OrderHasProductRepo : BaseRepo<OrderHasProduct>, IOrderHasProductRepo
    {
        public OrderHasProductRepo(EComContext db, ILogger logger) : base(db, logger) { }

    }
}
