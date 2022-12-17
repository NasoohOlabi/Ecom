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
}
