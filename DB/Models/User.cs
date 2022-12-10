using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Notifications = new HashSet<Notification>();
            Products = new HashSet<Product>();
            Ratings = new HashSet<Rating>();
            WishLists = new HashSet<WishList>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string BirthDate { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public long RoleId { get; set; }
        public bool IsVerified { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Role? Role { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
