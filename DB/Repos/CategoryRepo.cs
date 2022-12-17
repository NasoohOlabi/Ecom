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
        public CategoryRepo(EComContext db, ILogger logger) : base(db, logger) { }

        public void UpdateAttributeList(long id, IEnumerable<long> attributesIds)
        {
            var category = _dbSet
                .Include("CategoryHasAttributes")
                .Include("CategoryHasAttributes.Attribute")
                .First(x => x.Id == id);

            foreach (var cha in category.CategoryHasAttributes)
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
                        CategoryId = id
                    });
                }
            }

        }

    }
}
