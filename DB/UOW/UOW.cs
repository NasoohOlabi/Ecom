using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models;

namespace DB.UOW
{
    public class UOW : IUOW
    {

        protected EComContext _db { get; set; }

        public UOW(EComContext db)
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
