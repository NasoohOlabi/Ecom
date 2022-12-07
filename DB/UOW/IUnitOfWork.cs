using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.IRepos;

namespace DB.UOW
{
    public interface IUnitOfWork
    {
        //public ICategoryRepo categoryRepo;

        public void SaveChanges();

        public void RollBack();
    }
}
