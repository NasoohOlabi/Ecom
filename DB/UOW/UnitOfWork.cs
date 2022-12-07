using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.IRepos;
using DB.Models;
using DB.Repos;
using Microsoft.Extensions.Logging;

namespace DB.UOW
{
    public class UnitOfWork : IUnitOfWork
    {

        protected readonly EComContext _db;

        private readonly ILogger _logger;

        private ICategoryRepo? _categoryRepositry;

        public ICategoryRepo CategoryRepositry
        {
            get
            {

                if (this._categoryRepositry == null)
                {
                    this._categoryRepositry = new CategoryRepo(_db, _logger);
                }
                return _categoryRepositry;
            }
        }

        public UnitOfWork(EComContext db, ILogger<Category> logger)
        {
            _db = db;
            _logger = logger;
        }
        public void RollBack()
        {
            _db.Dispose();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
