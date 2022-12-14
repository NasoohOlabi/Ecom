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
    public class CategoryRepo : BaseRepo<CategoryRepo,Category>, ICategoryRepo
    {
        public CategoryRepo(EComContext db, ILogger<CategoryRepo> logger) : base(db,logger)
        {
        }
    }
}
