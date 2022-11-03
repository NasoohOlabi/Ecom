using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Rating
    {
        public long Id { get; set; }
        public int Rate { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
