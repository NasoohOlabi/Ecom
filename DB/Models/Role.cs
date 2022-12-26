using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DB.Models
{
    public partial class Role : IdentityRole<long>
    {
        public Role()
        {
            RoleHasPermissions = new HashSet<RoleHasPermission>();
            Users = new HashSet<User>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }
        public override string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual ICollection<RoleHasPermission> RoleHasPermissions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
