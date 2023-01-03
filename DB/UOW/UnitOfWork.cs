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
        private readonly ILogger<IUnitOfWork> _logger;
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

        public UnitOfWork(
            EComContext db
            , ILogger<IUnitOfWork> logger
            , IAddressRepo AddressRepo
            , IAttachmentRepo AttachmentRepo
            , ICategoryRepo CategoryRepo
            , ICouponRepo CouponRepo
            , INotificationRepo NotificationRepo
            , IOrderRepo OrderRepo
            , IProductRepo ProductRepo
            , IRoleRepo RoleRepo
            , ISpecificationRepo SpecificationRepo
            , IUserRepo UserRepo
            , IAttachmentTypeRepo AttachmentTypeRepo
            , IAttributeRepo AttributeRepo
            , ICategoryHasAttributeRepo CategoryHasAttributeRepo
            , INotificationTypeRepo NotificationTypeRepo
            , IOrderHasProductRepo OrderHasProductRepo
            , IOrderStatusRepo OrderStatusRepo
            , IPermissionRepo PermissionRepo
            , IProductHasAttachmentRepo ProductHasAttachmentRepo
            , IProductHasCouponRepo ProductHasCouponRepo
            , IRatingRepo RatingRepo
            , IRoleHasPermissionRepo RoleHasPermissionRepo
            , IShippingRepo ShippingRepo
            , ISpecificationValueRepo SpecificationValueRepo
            , IWishListRepo WishListRepo
            )
        {
            _db = db;
            _logger = logger;
            this.Addresses = AddressRepo;
            this.Attachments = AttachmentRepo;
            this.Categories = CategoryRepo;
            this.Coupons = CouponRepo;
            this.Notifications = NotificationRepo;
            this.Orders = OrderRepo;
            this.Products = ProductRepo;
            this.Roles = RoleRepo;
            this.Specifications = SpecificationRepo;
            this.Users = UserRepo;
            this.AttachmentTypes = AttachmentTypeRepo;
            this.Attributes = AttributeRepo;
            this.CategoryHasAttributes = CategoryHasAttributeRepo;
            this.NotificationTypes = NotificationTypeRepo;
            this.OrderHasProducts = OrderHasProductRepo;
            this.OrderStatuses = OrderStatusRepo;
            this.Permissions = PermissionRepo;
            this.ProductHasAttachments = ProductHasAttachmentRepo;
            this.ProductHasCoupons = ProductHasCouponRepo;
            this.Ratings = RatingRepo;
            this.RoleHasPermissions = RoleHasPermissionRepo;
            this.Shippings = ShippingRepo;
            this.SpecificationValues = SpecificationValueRepo;
            this.WishLists = WishListRepo;
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
