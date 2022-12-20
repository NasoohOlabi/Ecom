using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DB.Models;

namespace Ecom.Models
{
    public class CategoryDetailsViewModel : BaseDetailsViewModel<Category>
    {
        public string Name { get; set; } = null!;

    }

    public class CategoryEditViewModel : BaseEditViewModel<Category>
    {
        public string Name { get; set; } = null!;

    }

    public class EditCategoryAttributesViewModel : BaseEditViewModel<Category>
    {
        public string Name { get; set; } = null!;
        public IEnumerable<AttributeDetailsViewModel>? AllAttributes { get; set; } = null!;
        public IEnumerable<AttributeDetailsViewModel>? CategoryAttributes { get; set; } = null!;

    }

}


