using DB.IRepos;
using DB.Models;
using DB.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repos
{
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(EComContext db, ILogger<CategoryRepo> logger) : base(db, logger) { }

        public void UpdateAttributeList(Category category, IEnumerable<long> attributesIds)
        {

            foreach (var cha in category.CategoryHasAttributes!)
            {
                if (!attributesIds.Any(x=> x == cha.Id))
                {
                    category.CategoryHasAttributes.Remove(cha);
                    _db.CategoryHasAttributes.Remove(cha);
                }
            }

            foreach (var attributeId in attributesIds)
            {
                if (!category.CategoryHasAttributes.Any(x => x.Id == attributeId))
                {
                    _db.CategoryHasAttributes.Add(new CategoryHasAttribute
                    {
                        AttributeId = attributeId,
                        CategoryId = category.Id
                    });
                }
            }

        }



        public void DeleteAttributeList(long id)
        {
            var category = _dbSet
                .Include("CategoryHasAttributes")
                .Include("CategoryHasAttributes.Attribute")
                .First(x => x.Id == id);

            foreach (var cha in category.CategoryHasAttributes!)
            {
                
                    category.CategoryHasAttributes.Remove(cha);
                    _db.CategoryHasAttributes.Remove(cha);
               
            }


        }
    }
}
