using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DB.Models;

namespace Ecom.Models
{
    public class RoleDetailsViewModel : BaseDetailsViewModel
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<RoleHasPermission>? RoleHasPermissions { get; set; }
        public virtual ICollection<User>? Users { get; set; }

    }

    public class RoleEditViewModel : BaseEditViewModel
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<RoleHasPermission>? RoleHasPermissions { get; set; }
        public virtual ICollection<User>? Users { get; set; }

    }

}


