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
        private readonly ILogger<IUnitOfWork> _logger;
        private readonly ILoggerFactory _loggerFactory;


        public IProductRepo ProductRepositry { get; private set; }
        public IAddressRepo AddressRepositry { get; private set; }
        public ISpecificationRepo SpecificationRepositry { get; private set; }
        public IOrderRepo OrderRepositry { get; private set; }
        public INotificationRepo NotificationRepositry { get; private set; }
        public ICouponRepo CouponRepositry { get; private set; }
        public ICategoryRepo CategoryRepositry { get; private set; }
        public IRatingRepo RatingRepositry { get; private set; }
        public IRoleRepo RoleRepositry { get; private set; }
        public IShippingRepo ShippingRepositry { get; private set; }
        public IUserRepo UserRepositry { get; private set; }
        public IWishListRepo WishListRepositry { get; private set; }


        public UnitOfWork(EComContext db, ILoggerFactory factory
            , IProductRepo Product
            , IAddressRepo Address
            , ISpecificationRepo Specification
            , IOrderRepo Order
            , INotificationRepo Notification
            , ICouponRepo Coupon
            , ICategoryRepo CategoryRepositry
            , IRatingRepo RatingRepositry
            , IRoleRepo RoleRepositry
            , IShippingRepo ShippingRepositry
            , IUserRepo UserRepositry
            , IWishListRepo WishListRepositry

            )
        {
            this.ProductRepositry = Product;
            this.AddressRepositry = Address;
            this.SpecificationRepositry = Specification;
            this.OrderRepositry = Order;
            this.NotificationRepositry = Notification;
            this.CouponRepositry = Coupon;
            this.CategoryRepositry = CategoryRepositry;
            this.RatingRepositry = RatingRepositry;
            this.RoleRepositry = RoleRepositry;
            this.ShippingRepositry = ShippingRepositry;
            this.UserRepositry = UserRepositry;
            this.WishListRepositry = WishListRepositry;
            _db = db;
            _loggerFactory = factory;
            _logger = factory.CreateLogger<IUnitOfWork>();
        }
        public void RollBack()
        {
            _db.Dispose();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void RollBackAsync()
        {
            _db.DisposeAsync();
        }
    }
}
