using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DB.Models;
using Attribute = DB.Models.Attribute;

namespace Ecom.Models
{
    public class AttributeDetailsViewModel : BaseDetailsViewModel<Attribute>
    {
        [Display(Name = "Attribute Name")]
        public string Name { get; set; } = null!;
        [Display(Name = "Value Type")]
        public SpecificationValueTypes ValueType { get; set; }
    }

    public class AttributeEditViewModel : BaseEditViewModel<Attribute>
    {
        [Display(Name = "Attribute Name")]
        public string Name { get; set; } = null!;

    }

}


