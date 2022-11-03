using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Coupon
    {
        public Coupon()
        {
            ProductHasCoupons = new HashSet<ProductHasCoupon>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public decimal Percentage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual ICollection<ProductHasCoupon> ProductHasCoupons { get; set; }
    }
}
