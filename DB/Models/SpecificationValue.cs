using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public enum SpecificationValueTypes
    {
        Int,
        String,
        Bool,
        Float
    }

    public partial class SpecificationValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Value { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public long SpecificationId { get; set; }

        public virtual Specification Specification { get; set; } = null!;
    }
}
