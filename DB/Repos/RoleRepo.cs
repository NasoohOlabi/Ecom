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
    public class RoleRepo : BaseRepo<RoleRepo, Role>, IRoleRepo
    {
        public RoleRepo(EComContext db, ILogger<RoleRepo> logger) : base(db, logger)
        {
        }
    }
}

