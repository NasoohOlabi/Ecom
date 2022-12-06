using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public partial class CategoryDetailsViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Modified At")]
        public DateTime ModifiedAt { get; set; }

    }

    public partial class CategoryEditViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;

    }

}


