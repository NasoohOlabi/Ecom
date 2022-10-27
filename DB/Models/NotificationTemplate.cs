using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class NotificationTemplate
    {
        public NotificationTemplate()
        {
            Notifications = new HashSet<Notification>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
