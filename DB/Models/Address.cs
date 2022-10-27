using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Country { get; set; } = null!;
        public long UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
