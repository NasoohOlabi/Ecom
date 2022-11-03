using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class CategoryHasAttribute
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public long AttributeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Attribute Attribute { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
}
