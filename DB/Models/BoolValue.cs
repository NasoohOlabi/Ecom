using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class BoolValue
    {
        public long Id { get; set; }
        public byte[] Value { get; set; } = null!;

        public virtual Spec IdNavigation { get; set; } = null!;
    }
}
