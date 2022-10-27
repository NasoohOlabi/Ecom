using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Coupon
    {
        public Coupon()
        {
            CouponHasProducts = new HashSet<CouponHasProduct>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Percentage { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<CouponHasProduct> CouponHasProducts { get; set; }
    }
}
