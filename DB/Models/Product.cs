using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderHasProducts = new HashSet<OrderHasProduct>();
            ProductHasAttachments = new HashSet<ProductHasAttachment>();
            ProductHasCoupons = new HashSet<ProductHasCoupon>();
            Ratings = new HashSet<Rating>();
            Specifications = new HashSet<Specification>();
            WishLists = new HashSet<WishList>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
        public long SellerId { get; set; }
        public long RatingSum { get; set; }
        public long RatingCount { get; set; }
        public long OrderCount { get; set; }
        public decimal Discount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Category? Category { get; set; } = null!;
        public virtual User? Seller { get; set; } = null!;
        public virtual ICollection<OrderHasProduct>? OrderHasProducts { get; set; }
        public virtual ICollection<ProductHasAttachment>? ProductHasAttachments { get; set; }
        public virtual ICollection<ProductHasCoupon>? ProductHasCoupons { get; set; }
        public virtual ICollection<Rating>? Ratings { get; set; }
        public virtual ICollection<Specification>? Specifications { get; set; }
        public virtual ICollection<WishList>? WishLists { get; set; }
    }
}