using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Category
    {
        public Category()
        {
            CategoryHasAttributes = new HashSet<CategoryHasAttribute>();
            InverseCategoryNavigation = new HashSet<Category>();
            Products = new HashSet<Product>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public long CategoryId { get; set; }

        public virtual Category CategoryNavigation { get; set; } = null!;
        public virtual ICollection<CategoryHasAttribute> CategoryHasAttributes { get; set; }
        public virtual ICollection<Category> InverseCategoryNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
