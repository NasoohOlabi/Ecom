using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class CouponHasProduct
    {
        public long Id { get; set; }
        public long CouponId { get; set; }
        public long ProductId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual Coupon Coupon { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
