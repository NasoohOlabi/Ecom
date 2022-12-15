using DB.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class SelectAttributeViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;

    }
    public class EditCategoryAttributesViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<SelectAttributeViewModel>? SelectAttributes { get; set; } = null!;
        public IEnumerable<SelectAttributeViewModel>? CategoryAttributes { get; set; } = null!;
        
    }
    public class CreateAttributeViewModel
    {
        [Required]
        public string Name { get; set; } = null!;

    }
}
