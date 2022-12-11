using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ecom.Models
{
    public class BaseDetailsViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Modified At")]
        public DateTime ModifiedAt { get; set; }
    }

    public class BaseEditViewModel
    {
        public long Id { get; set; }
    }

}
