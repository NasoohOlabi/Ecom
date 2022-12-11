using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DB.Models;

namespace Ecom.Models
{
    public class CategoryDetailsViewModel : BaseDetailsViewModel
    {
        public string Name { get; set; } = null!;

    }

    public class CategoryEditViewModel : BaseEditViewModel
    {
        public string Name { get; set; } = null!;

    }

}


