using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DB.Models;

namespace Ecom.Models
{
    public class ProductDetailsViewModel : BaseDetailsViewModel<Product>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public Category? Category { get; set; }
        public User? Seller { get; set; }
        public long Rating { get; set; }

        [Display(Name = "Number of Orders")]
        public long OrderCount { get; set; }
        public decimal Discount { get; set; }

    }

    public class ProductEditViewModel : BaseEditViewModel<Product>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public long CategoryId { get; set; }

        [Display(Name = "Seller")]
        public long SellerId { get; set; }
        public Category? Category { get; set; }
        public User? Seller { get; set; }
        public decimal Discount { get; set; }

    }

    public class EditProductSpecificationsViewModel : BaseEditViewModel<Specification>
    {
        public string Name { get; set; } = null!;
        public IEnumerable<AttributeDetailsViewModel>? CategoryAttributes { get; set; } = null;
        public IEnumerable<AttributeDetailsViewModel>? AllAttributes { get; set; } = null;
        public IEnumerable<SelectSpecificationViewModel>? ProductSpecifications { get; set; } = null;

    }

}


