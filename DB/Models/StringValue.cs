using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class StringValue
    {
        public long Id { get; set; }
        public string Value { get; set; } = null!;

        public virtual Spec IdNavigation { get; set; } = null!;
    }
}
