using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Bigintvalue
    {
        public long Id { get; set; }
        public long Value { get; set; }

        public virtual Spec IdNavigation { get; set; } = null!;
    }
}
