﻿using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace DB.IRepos
{
    public interface IUserRepo : IBaseRepo<User>
    {
    }
}
