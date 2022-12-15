﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Category
    {
        public Category()
        {
            CategoryHasAttributes = new HashSet<CategoryHasAttribute>();
            Products = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual ICollection<CategoryHasAttribute>? CategoryHasAttributes { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
