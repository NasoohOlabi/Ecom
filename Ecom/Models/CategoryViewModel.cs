using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DB.Models;

namespace Ecom.Models
{
    public class CategoryDetailsViewModel
    {
        public CategoryDetailsViewModel()
        {
        }
        public CategoryDetailsViewModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
            this.ModifiedAt = category.ModifiedAt;
            this.CreatedAt = category.CreatedAt;
        }
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Modified At")]
        public DateTime ModifiedAt { get; set; }

    }

    public class CategoryEditViewModel
    {

        public CategoryEditViewModel()
        {
        }
        public CategoryEditViewModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }
        public long Id { get; set; }
        public string Name { get; set; } = null!;

    }

}


