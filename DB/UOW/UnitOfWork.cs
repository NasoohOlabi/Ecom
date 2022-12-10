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
        public ISpecificationRepo Specifications { get; private set; }
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
            Specifications = new SpecificationRepo(_db, _logger);
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
