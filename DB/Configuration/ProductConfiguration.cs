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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        
        private List<Product> _products = new List<Product>();

        private void FillDummyProducts()
        {
            Product product = new Product
            {
                Id = 1,
                Name = "DB Product",
                Description = "Sample DB Product",
                CategoryId = 1,
                Discount = 0,
                OrderCount = 0,
                Price = 100,
                RatingCount = 0,
                RatingSum = 0,
                SellerId = 1,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            _products.Add(product);
        }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            FillDummyProducts();
            builder.HasData
            (
                _products
            );
        }
    }
}
