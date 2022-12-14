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
    public class UserRepo : BaseRepo<UserRepo, User>, IUserRepo
    {
        public UserRepo(EComContext db, ILogger<UserRepo> logger) : base(db, logger)
        {
        }
    }
}
