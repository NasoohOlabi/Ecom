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
    public class SpecificationRepo : BaseRepo<SpecificationRepo, Specification>, ISpecificationRepo
    {
        public SpecificationRepo(EComContext db, ILogger<SpecificationRepo> logger) : base(db,logger)
        {
        }
    }
}
