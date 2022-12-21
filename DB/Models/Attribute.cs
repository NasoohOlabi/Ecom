using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public enum SpecificationValueTypes
    {
        String,
        Int,
        Bool,
        Float,
        Color,
        Date
    }
    public partial class Attribute
    {
        public Attribute()
        {
            CategoryHasAttributes = new HashSet<CategoryHasAttribute>();
            Specifications = new HashSet<Specification>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public SpecificationValueTypes ValueType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual ICollection<CategoryHasAttribute>? CategoryHasAttributes { get; set; }
        public virtual ICollection<Specification>? Specifications { get; set; }
    }
}
