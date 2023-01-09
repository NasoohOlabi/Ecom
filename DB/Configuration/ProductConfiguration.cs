using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.DummyData;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace DB.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        
        private List<Product> _products = new List<Product>();

        private void FillDummyProducts()
        {

            using (StreamReader r = new StreamReader(@"../DB/DummyData/products.json"))
            {
                string json = r.ReadToEnd();
                var products = JsonConvert.DeserializeObject<List<DummyDataModel>>(json);

                long counter = 1;
                foreach (var product in products!)
                {
                    string categoryName = product.Category;
                    string normalizedName = char.ToUpper(categoryName[0]) + categoryName[1..].ToLower();

                    Category category = CategoryConfiguration.Categories.First(cat => cat.Name == normalizedName);

                    _products.Add(new Product
                    {
                        Id = counter,
                        Name = product.Name,
                        Description = product.Description,
                        CategoryId = category.Id,
                        Discount = product.Discount,
                        Price = product.Price,
                        OrderCount = 0,
                        RatingCount = 0,
                        RatingSum = 0,
                        SellerId = 1,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                    });
                    counter++;
                }
            }
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
