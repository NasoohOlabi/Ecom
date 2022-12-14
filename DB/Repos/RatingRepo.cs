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
    public class RatingRepo : BaseRepo<RatingRepo,Rating>, IRatingRepo
    {
        public RatingRepo(EComContext db, ILogger<RatingRepo> logger) : base(db, logger)
        {
        }
    }
}
