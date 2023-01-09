using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace DB.Configuration
{
    public class AspNetUserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<long>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<long>> builder)
        {
            builder.ToTable("AspNetUserRoles");
            builder.HasData
            (
                new IdentityUserRole<long>
                {
                    UserId = 1,
                    RoleId = 1
                }
            );
        }
    }
}
