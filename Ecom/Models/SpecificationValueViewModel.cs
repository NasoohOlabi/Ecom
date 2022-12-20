using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DB.Models;

namespace Ecom.Models
{
    public class SpecificationValueDetailsViewModel : BaseDetailsViewModel<SpecificationValue>
    {
        public string Value { get; set; } = null!;

    }

    public class SpecificationValueEditViewModel : BaseEditViewModel<SpecificationValue>
    {
        public string Value { get; set; } = null!;

    }

}


