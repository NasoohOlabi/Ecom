using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class StringValue
    {
        public long Id { get; set; }
        public string Value { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public long SpecificationId { get; set; }

        public virtual Specification Specification { get; set; } = null!;
    }
}
