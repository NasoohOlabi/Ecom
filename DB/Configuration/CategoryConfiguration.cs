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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public static readonly List<Category> Categories = new List<Category>();

        private void FillDummyCategories()
        {

            using (StreamReader r = new StreamReader(@"../DB/DummyData/products.json"))
            {
                string json = r.ReadToEnd();
                var products = JsonConvert.DeserializeObject<List<DummyDataModel>>(json);

                // Fill unique values into a set
                HashSet<string> cats = new HashSet<string>();

                foreach (var product in products!)
                {
                    string name = product.Category;
                    string normalizedName = char.ToUpper(name[0]) + name.Substring(1).ToLower();
                    cats.Add(normalizedName);
                }

                long counter = 1;

                foreach (var category in cats)
                {
                    var cat = Categories.FirstOrDefault(c => c.Id == counter);

                    if(cat != null)
                    {
                        continue;
                    }

                    Categories.Add(new Category
                    {
                        Id = counter,
                        Name = category,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                    });
                    counter++;
                }
            }
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            FillDummyCategories();
            builder.HasData
            (
                Categories
            );
        }
    }
}
