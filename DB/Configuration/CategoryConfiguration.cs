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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        private readonly List<Category> _categories = new List<Category>();

        private void FillDummyCategories()
        {
            Category category = new Category
            {
                Id = 1,
                Name = "DB Category",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            _categories.Add(category);
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            FillDummyCategories();
            builder.HasData
            (
                _categories
            );
        }
    }
}
