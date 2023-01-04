using DB.IRepos;
using DB.Models;
using DB.UOW;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repos
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(EComContext db, ILogger<UserRepo> logger) : base(db, logger) {}

    }
}
