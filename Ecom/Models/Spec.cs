using DB.Models;
using System.ComponentModel.DataAnnotations;
using Attribute = DB.Models.Attribute;

namespace Ecom.Models
{
    public class SelectAttributeViewModel : BaseEditViewModel<Attribute>
    {
        public string Name { get; set; } = null!;

    }
    public class EditCategoryAttributesViewModel : BaseEditViewModel<Category>
    {
        public string Name { get; set; } = null!;
        public IEnumerable<SelectAttributeViewModel>? SelectAttributes { get; set; } = null!;
        public IEnumerable<SelectAttributeViewModel>? CategoryAttributes { get; set; } = null!;

    }
    public class CreateAttributeViewModel : BaseCreateViewModel<Attribute>
    {
        [Required]
        public string Name { get; set; } = null!;

    }
    public class SelectValueViewModel : BaseEditViewModel<SpecificationValue> {
        public string Value { get; set; } = null!;
    }
    public class EditAttributeViewModel : BaseEditViewModel<Attribute>
    {
        public string Name { get; set; } = null!;
    }
    public class SelectSpecificationViewModel : BaseEditViewModel<Attribute>
    {
        public EditAttributeViewModel? Attribute { get; set; } = null;
        public SelectValueViewModel? Value { get; set; } = null;

    }

    public class EditProductSpecificationsViewModel : BaseEditViewModel<Specification>
    {
        public string Name { get; set; } = null!;
        public IEnumerable<SelectAttributeViewModel>? CategoryAttributes { get; set; } = null;
        public IEnumerable<SelectAttributeViewModel>? AllAttributes { get; set; } = null;
        public IEnumerable<SelectSpecificationViewModel>? ProductSpecifications { get; set; } = null;

    }
}
