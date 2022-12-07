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
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {

        private readonly ILogger<Category> _logger;

        public CategoryRepo(EComContext db, ILogger<Category> logger) : base(db)
        {
            _logger = logger;
        }
    }
}
