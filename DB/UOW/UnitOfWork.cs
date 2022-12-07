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
        protected readonly ILogger<Category> _logger;

        private IProductRepo? _product;
        public IProductRepo Products
        {
            get
            {
                _product ??= new ProductRepo(_db);
                return _product;
            }
        }
        private IAddressRepo? _address;
        public IAddressRepo Adresses
        {
            get
            {
                _address ??= new AddressRepo(_db);
                return _address;
            }
        }
        private ISpecificationRepo? _specification;
        public ISpecificationRepo Specifications
        {
            get
            {
                _specification ??= new SpecificationRepo(_db);
                return _specification;
            }
        }
        
        private IOrderRepo? _order = null;
        public IOrderRepo Orders
        {
            get
            {
                _order ??= new OrderRepo(_db);
                return _order;
            }
        }
        private INotificationRepo? _notification;
        public INotificationRepo Notifications
        {
            get
            {
                _notification ??= new NotificationRepo(_db);
                return _notification;
            }
        }
        private ICouponRepo? _coupon = null;
        public ICouponRepo Coupons
        {
            get
            {
                _coupon ??= new CouponRepo(_db);
                return _coupon;
            }
        }

        private ICategoryRepo? _categoryRepositry;

        public ICategoryRepo CategoryRepositry
        {
            get
            {
                this._categoryRepositry ??= new CategoryRepo(_db, _logger);
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
