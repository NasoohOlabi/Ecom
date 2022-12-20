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
        public string Name { get; set; } = null!;

    }

    public class AttributeEditViewModel : BaseEditViewModel<Attribute>
    {
        public string Name { get; set; } = null!;

    }

}


