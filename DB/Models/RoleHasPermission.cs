using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class RoleHasPermission
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long PermissionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Permission Permission { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
