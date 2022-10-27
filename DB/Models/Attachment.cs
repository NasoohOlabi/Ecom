using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Attachment
    {
        public Attachment()
        {
            AttachmentHasProducts = new HashSet<AttachmentHasProduct>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Path { get; set; } = null!;
        public long AttachmentTypeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual AttachmentType AttachmentType { get; set; } = null!;
        public virtual ICollection<AttachmentHasProduct> AttachmentHasProducts { get; set; }
    }
}
