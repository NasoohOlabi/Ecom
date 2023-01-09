using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            var user = new User
            {
                Id = 1,
                FirstName = "Site",
                LastName = "Owner",
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                PhoneNumber = "0987654321",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com",
                BirthDate = new DateTime(2000, 10, 10),
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, "Admin!123");

            builder.HasData
            (
                user
            );
            
        }
    }
}
