using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Spec
    {
        public long Id { get; set; }
        public long? ValueType { get; set; }
        public string ValueId { get; set; } = null!;
        public long ProductId { get; set; }
        public long AttributeId { get; set; }

        public virtual Attribute Attribute { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Bigintvalue? Bigintvalue { get; set; }
        public virtual BoolValue? BoolValue { get; set; }
        public virtual StringValue? StringValue { get; set; }
    }
}
