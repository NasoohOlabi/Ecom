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
        public void SaveChanges();

        public Task SaveChangesAsync();

        public void RollBack();

        public void RollBackAsync();
    }
}
