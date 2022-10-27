using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class AttachmentHasProduct
    {
        public long Id { get; set; }
        public long AttachmentId { get; set; }
        public long ProductId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual Attachment Attachment { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
