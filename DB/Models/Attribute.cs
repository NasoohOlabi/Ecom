using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Attribute
    {
        public Attribute()
        {
            CategoryHasAttributes = new HashSet<CategoryHasAttribute>();
            Specs = new HashSet<Spec>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<CategoryHasAttribute> CategoryHasAttributes { get; set; }
        public virtual ICollection<Spec> Specs { get; set; }
    }
}
