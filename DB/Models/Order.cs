using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderHasProducts = new HashSet<OrderHasProduct>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string DeliveredAt { get; set; } = null!;
        public long OrderStatusId { get; set; }
        public long UserId { get; set; }
        public long AddressId { get; set; }
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
        public long ShippingId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual OrderStatus OrderStatus { get; set; } = null!;
        public virtual Shipping Shipping { get; set; } = null!;
        public virtual ICollection<OrderHasProduct> OrderHasProducts { get; set; }
    }
}
