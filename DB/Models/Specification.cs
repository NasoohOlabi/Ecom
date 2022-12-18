using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Specification
    {
        public Specification()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ValueType { get; set; }
        public long ProductId { get; set; }
        public long AttributeId { get; set; }
        public long SpecificationValueId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Attribute? Attribute { get; set; } = null!;
        public virtual Product? Product { get; set; } = null!;
        public virtual SpecificationValue? SpecificationValue { get; set; }
    }
}
