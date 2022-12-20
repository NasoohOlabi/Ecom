using DB.Models;
using System.ComponentModel.DataAnnotations;
using Attribute = DB.Models.Attribute;

namespace Ecom.Models
{

    public class SpecificationDetailsViewModel : BaseDetailsViewModel<Specification>
  {
        public long ValueType { get; set; }

        public long ProductId { get; set; }
        public long AttributeId { get; set; }
        public long SpecificationValueId { get; set; }

        public virtual Attribute? Attribute { get; set; } = null!;
        public virtual Product? Product { get; set; } = null!;
        public virtual SpecificationValue? SpecificationValue { get; set; }

    }

    public class SpecificationEditViewModel : BaseEditViewModel<Specification>
  {
        public long ValueType { get; set; }
        
        public long ProductId { get; set; }
        public long AttributeId { get; set; }
        public long SpecificationValueId { get; set; }

        public virtual Attribute? Attribute { get; set; } = null!;
        public virtual Product? Product { get; set; } = null!;
        public virtual SpecificationValue? SpecificationValue { get; set; }

    }

    public class SelectSpecificationViewModel : BaseEditViewModel<Attribute>
    {

        public long AttributeId { get; set; }
        public AttributeDetailsViewModel? Attribute { get; set; } = null;

        public long SpecificationValueId { get; set; }
        public SpecificationValueDetailsViewModel? SpecificationValue { get; set; } = null;

    }

}
