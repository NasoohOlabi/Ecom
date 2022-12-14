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
        public IProductRepo ProductRepositry{get;}
        public IAddressRepo AddressRepositry{get;}
        public ISpecificationRepo SpecificationRepositry{get;}
        public IOrderRepo OrderRepositry{get;}
        public INotificationRepo NotificationRepositry{get;}
        public ICouponRepo CouponRepositry{get;}
        public ICategoryRepo CategoryRepositry{get;}
        public IRatingRepo RatingRepositry{get;}
        public IRoleRepo RoleRepositry{get;}
        public IShippingRepo ShippingRepositry{get;}
        public IUserRepo UserRepositry{get;}
        public IWishListRepo WishListRepositry { get; }

        public void SaveChanges();

        public Task SaveChangesAsync();

        public void RollBack();

        public void RollBackAsync();
    }
}
