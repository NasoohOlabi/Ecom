using DB.IRepos;
using DB.Models;
using DB.UOW;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repos
{
    public class SelectAttributeViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;

    }
    public class SelectValueViewModel
    {
        public long Id { get; set; }
        public string Value { get; set; } = "";
    }
    public class EditAttributeViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
    }
    public class SelectSpecificationViewModel
    {
        public long Id { get; set; }
        public EditAttributeViewModel? Attribute { get; set; } = null;
        public SelectValueViewModel Value { get; set; } = null!;

    }
    public class EditProductSpecificationsViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<SelectAttributeViewModel>? CategoryAttributes { get; set; } = null;
        public IEnumerable<SelectAttributeViewModel>? AllAttributes { get; set; } = null;
        public IEnumerable<SelectSpecificationViewModel>? ProductSpecifications { get; set; } = null;

    }
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        public ProductRepo(EComContext db, ILogger logger) : base(db, logger) { }

        public void UpdateRating(long id, long count, long sum)
        {
            try
            {
                var prod = _db.Products.Single(x => x.Id == id);
                prod.RatingSum = sum;
                prod.RatingCount = count;
            }
            catch (InvalidOperationException)
            {
                string message = $"A Product with id {id} Was Deleted before Rating Was Updated to count {count} and sum {sum}";
                if (_logger != null)
                    _logger.LogDebug(message);
            }
        }
        // Tuple<SpecifiationId, AttributeId, ValueId, Value>
        public void UpdateSpecificationsList(EditProductSpecificationsViewModel eProductSpecifications)
        {

            var product = Get(
               x => x.Id == eProductSpecifications.Id,
               includeProperties:
               "Specifications,Specifications.Attribute,Specifications.SpecificationValue,Category,Category.CategoryHasAttributes,Category.CategoryHasAttributes.Attribute")
               .First();

            foreach (var spec in product.Specifications)
            {
                if (!eProductSpecifications.ProductSpecifications.Select(x => x.Id).Any(x => x == spec.Id))
                {
                    _db.Specifications.Remove(spec);
                    _db.SpecificationValues.Remove(spec.SpecificationValue);
                }
            }

            foreach (var newSpec in eProductSpecifications.ProductSpecifications)
            {
                if (!product.Specifications.Select(x => x.Id).Any(x => x == newSpec.Id))
                {
                    var val = _db.Specifications.Add(new Specification
                    {
                        AttributeId = newSpec.Attribute.Id,
                        ProductId = eProductSpecifications.Id,
                        ValueType = 0,
                        SpecificationValue = new SpecificationValue
                        {
                            Value = newSpec.Value.Value,
                        }
                    });
                }
            }
        }
    }
}
