using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Notification
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public long UserId { get; set; }
        public long NotificationTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual NotificationType NotificationType { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
