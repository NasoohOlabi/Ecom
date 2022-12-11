using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.IRepos;
using DB.Models;
using DB.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DB.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly EComContext _db;
        private readonly ILogger _logger;
        public IAddressRepo Addresses { get; private set; }
        public IAttachmentRepo Attachments { get; private set; }
        public ICategoryRepo Categories { get; private set; }
        public ICouponRepo Coupons { get; private set; }
        public INotificationRepo Notifications { get; private set; }
        public IOrderRepo Orders { get; private set; }
        public IProductRepo Products { get; private set; }
        public IRoleRepo Roles { get; private set; }
        public ISpecificationRepo Specifications { get; private set; }
        public IUserRepo Users { get; private set; }
        public IAttachmentTypeRepo AttachmentTypes { get; private set; }
        public IAttributeRepo Attributes { get; private set; }
        public ICategoryHasAttributeRepo CategoryHasAttributes { get; private set; }
        public INotificationTypeRepo NotificationTypes { get; private set; }
        public IOrderHasProductRepo OrderHasProducts { get; private set; }
        public IOrderStatusRepo OrderStatuses { get; private set; }
        public IPermissionRepo Permissions { get; private set; }
        public IProductHasAttachmentRepo ProductHasAttachments { get; private set; }
        public IProductHasCouponRepo ProductHasCoupons { get; private set; }
        public IRatingRepo Ratings { get; private set; }
        public IRoleHasPermissionRepo RoleHasPermissions { get; private set; }
        public IShippingRepo Shippings { get; private set; }
        public ISpecificationValueRepo SpecificationValues { get; private set; }
        public IWishListRepo WishLists { get; private set; }

        public UnitOfWork(EComContext db, ILoggerFactory loggerFactory)
        {
            _db = db;
            _logger = loggerFactory.CreateLogger("logs");
            Addresses = new AddressRepo(_db, _logger);
            Attachments = new AttachmentRepo(_db, _logger);
            Categories = new CategoryRepo(_db, _logger);
            Coupons = new CouponRepo(_db, _logger);
            Notifications = new NotificationRepo(_db, _logger);
            Orders = new OrderRepo(_db, _logger);
            Products = new ProductRepo(_db, _logger);
            Roles = new RoleRepo(_db, _logger);
            Specifications = new SpecificationRepo(_db, _logger);
            Users = new UserRepo(_db, _logger);
            AttachmentTypes = new AttachmentTypeRepo(_db, _logger);
            Attributes = new AttributeRepo(_db, _logger);  
            CategoryHasAttributes = new CategoryHasAttributeRepo(_db, _logger);  
            NotificationTypes = new NotificationTypeRepo(_db, _logger);  
            OrderHasProducts = new OrderHasProductRepo(_db, _logger);  
            OrderStatuses = new OrderStatusRepo(_db, _logger);  
            Permissions = new PermissionRepo(_db, _logger);  
            ProductHasAttachments = new ProductHasAttachmentRepo(_db, _logger);
            ProductHasCoupons = new ProductHasCouponRepo(_db, _logger);
            Ratings = new RatingRepo(_db, _logger);
            RoleHasPermissions = new RoleHasPermissionRepo(_db, _logger);
            Shippings = new ShippingRepo(_db, _logger);
            SpecificationValues = new SpecificationValueRepo(_db, _logger);
            WishLists = new WishListRepo(_db, _logger);
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

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
