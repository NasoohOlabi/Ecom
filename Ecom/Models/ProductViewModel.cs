﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DB.Models;

namespace Ecom.Models
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel(Product product,Category category,User seller)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Price = product.Price;
            this.Seller = seller;
            this.OrderCount = product.OrderCount;
            this.Discount = product.Discount;
            this.Description = product.Description;
            this.ModifiedAt = product.ModifiedAt;
            this.CreatedAt = product.CreatedAt;
            this.Rating = product.RatingSum/product.RatingCount;
            this.Category = category;
        }
        
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Modified At")]
        public DateTime ModifiedAt { get; set; }
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public User Seller { get; set; }
        public long Rating { get; set; }
        public long OrderCount { get; set; }
        public decimal Discount { get; set; }

    }

    public class ProductEditViewModel
    {
        public ProductEditViewModel(Product product, Category category, User seller)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Price = product.Price;
            this.Seller = seller;
            this.Discount = product.Discount;
            this.Description = product.Description;
            this.Category = category;
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public User Seller { get; set; }
        public decimal Discount { get; set; }

    }

}


