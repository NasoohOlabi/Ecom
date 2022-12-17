using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class CategoryHasAttribute
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public long AttributeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Attribute? Attribute { get; set; } = null!;
        public virtual Category? Category { get; set; } = null!;
    }
}
