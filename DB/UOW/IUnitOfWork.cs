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
        IAddressRepo Addresses { get; }
        IAttachmentRepo Attachments { get; }
        IAttachmentTypeRepo AttachmentTypes { get; }
        IAttributeRepo Attributes { get; }
        ICategoryHasAttributeRepo CategoryHasAttributes { get; }
        ICategoryRepo Categories { get; }
        ICouponRepo Coupons { get; }
        INotificationRepo Notifications { get; }
        INotificationTypeRepo NotificationTypes { get; }
        IOrderHasProductRepo OrderHasProducts { get; }
        IOrderRepo Orders { get; }
        IOrderStatusRepo OrderStatuses { get; }
        IPermissionRepo Permissions { get; }
        IProductHasAttachmentRepo ProductHasAttachments { get; }
        IProductHasCouponRepo ProductHasCoupons { get; }
        IProductRepo Products { get; }
        IRatingRepo Ratings { get; }
        IRoleHasPermissionRepo RoleHasPermissions { get; }
        IRoleRepo Roles { get; }
        IShippingRepo Shippings { get; }
        ISpecificationRepo Specifications { get; }
        ISpecificationValueRepo SpecificationValues { get; }
        IUserRepo Users { get; }
        IWishListRepo WishLists { get; }
        public void SaveChanges();

        public Task SaveChangesAsync();

        public void RollBack();

        public void RollBackAsync();
    }
}
