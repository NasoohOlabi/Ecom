using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.UOW
{
    public interface IUOW
    {
        //public IUserRepo UserRepo { get; set };

        public void SaveChanges();

        public void RollBack();
    }
}
