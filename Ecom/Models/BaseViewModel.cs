using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ecom.Models
{
    public class BaseDetailsViewModel<T> where T : class
    {
        public long Id { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Modified At")]
        public DateTime ModifiedAt { get; set; }
    }

    public class BaseEditViewModel<T> where T : class
    {
        public long Id { get; set; }
    }

    public class BaseCreateViewModel<T> where T : class
    {

    }
}
