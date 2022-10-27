using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class AttachmentType
    {
        public AttachmentType()
        {
            Attachments = new HashSet<Attachment>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
