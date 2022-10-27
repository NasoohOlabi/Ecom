using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Permission
    {
        public Permission()
        {
            RoleHasPermissions = new HashSet<RoleHasPermission>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<RoleHasPermission> RoleHasPermissions { get; set; }
    }
}
