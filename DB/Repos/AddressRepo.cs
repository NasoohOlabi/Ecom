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
    public class AddressRepo : BaseRepo<Product>, IAddressRepo
    {

        private readonly ILogger<AddressRepo>? _logger;


        public AddressRepo(EComContext db, ILogger<AddressRepo>? logger = null) : base(db)
        {
            _logger = logger;
        }

      
    }
}
