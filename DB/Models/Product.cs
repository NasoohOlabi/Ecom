using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Product
    {
        public Product()
        {
            AttachmentHasProducts = new HashSet<AttachmentHasProduct>();
            CouponHasProducts = new HashSet<CouponHasProduct>();
            OrderHasProducts = new HashSet<OrderHasProduct>();
            Ratings = new HashSet<Rating>();
            Specs = new HashSet<Spec>();
            WishLists = new HashSet<WishList>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
        public long SellerId { get; set; }
        public long? RatingSum { get; set; }
        public long? RatingCount { get; set; }
        public string OrderCount { get; set; } = null!;
        public decimal Discount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual User Seller { get; set; } = null!;
        public virtual ICollection<AttachmentHasProduct> AttachmentHasProducts { get; set; }
        public virtual ICollection<CouponHasProduct> CouponHasProducts { get; set; }
        public virtual ICollection<OrderHasProduct> OrderHasProducts { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Spec> Specs { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
