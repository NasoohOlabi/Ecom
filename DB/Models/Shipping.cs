using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Shipping
    {
        public Shipping()
        {
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
