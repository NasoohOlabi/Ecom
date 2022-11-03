using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Specification
    {
        public Specification()
        {
            BoolValues = new HashSet<BoolValue>();
            FloatValues = new HashSet<FloatValue>();
            IntValues = new HashSet<IntValue>();
            StringValues = new HashSet<StringValue>();
        }

        public long Id { get; set; }
        public long ValueType { get; set; }
        public long ProductId { get; set; }
        public long AttributeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Attribute Attribute { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<BoolValue> BoolValues { get; set; }
        public virtual ICollection<FloatValue> FloatValues { get; set; }
        public virtual ICollection<IntValue> IntValues { get; set; }
        public virtual ICollection<StringValue> StringValues { get; set; }
    }
}
