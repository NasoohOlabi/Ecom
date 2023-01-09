using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasData
            (
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                }
                ,
                new Role
                {
                    Id = 2,
                    Name = "User",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                }
            );
        }
    }
}
