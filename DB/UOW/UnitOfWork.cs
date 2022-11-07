using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models;

namespace DB.UOW
{
    public class UnitOfWork : IUnitOfWork
    {

        protected readonly EComContext _db;

        public UnitOfWork(EComContext db)
        {
            _db = db;
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
