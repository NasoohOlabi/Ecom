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
    public class AddressRepo : BaseRepo<AddressRepo,Address>, IAddressRepo
    {
        public AddressRepo(EComContext db, ILogger<AddressRepo> logger) : base(db, logger)
        {
        }
    }
}
