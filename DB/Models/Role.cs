using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleHasPermissions = new HashSet<RoleHasPermission>();
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual ICollection<RoleHasPermission> RoleHasPermissions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
