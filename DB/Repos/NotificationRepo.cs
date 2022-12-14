using DB.IRepos;
using DB.Models;
using DB.UOW;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repos
{
    public class NotificationRepo : BaseRepo<NotificationRepo,Notification>, INotificationRepo
    {
        public NotificationRepo(EComContext db, ILogger<NotificationRepo> logger) : base(db, logger)
        {
        }
    }
}
