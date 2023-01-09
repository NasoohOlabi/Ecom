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
    public class AttachmentTypeConfiguration : IEntityTypeConfiguration<AttachmentType>
    {
        public void Configure(EntityTypeBuilder<AttachmentType> builder)
        {
            builder.ToTable("AttachmentType");
            builder.HasData
            (
                new AttachmentType
                {
                    Id = 1,
                    Name = "Product Thumbnail",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                }
                ,
                new AttachmentType
                {
                    Id = 2,
                    Name = "Product Image",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                }
            );
        }
    }
}
