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
        ICategoryRepo Categories { get; }
        ICouponRepo Coupons { get; }
        INotificationRepo Notifications { get; }
        IOrderRepo Orders { get; }
        IProductRepo Products { get; }
        ISpecificationRepo Specifications { get; }
        public void SaveChanges();

        public Task SaveChangesAsync();

        public void RollBack();

        public void RollBackAsync();
    }
}
