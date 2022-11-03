using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class FloatValue
    {
        public long Id { get; set; }
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public long SpecificationId { get; set; }

        public virtual Specification Specification { get; set; } = null!;
    }
}
