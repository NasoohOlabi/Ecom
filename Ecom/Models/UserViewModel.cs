using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DB.Models;

namespace Ecom.Models
{
    public class UserDetailsViewModel : BaseDetailsViewModel<User>
    {

        [Display(Name ="First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
        public string FullName { get { return FirstName + " " + LastName; } }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public string BirthDate { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Display(Name ="Verified User")]
        public bool IsVerified { get; set; }

        [Display(Name = "Role")]
        public long RoleId { get; set; }

        [DataType(DataType.ImageUrl)]
        public string? ProfilePicture { get; set; }
        public virtual Product? Product { get; set; } = null!;
        public virtual User? User { get; set; } = null!;
        public virtual Role? Role { get; set; } = null!;

    }

    public class UserEditViewModel : BaseEditViewModel<User>
    {

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public string BirthDate { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Display(Name = "Role")]
        public long RoleId { get; set; }

        [DataType(DataType.ImageUrl)]
        public string? ProfilePicture { get; set; }
        public virtual Product? Product { get; set; } = null!;
        public virtual User? User { get; set; } = null!;
        public virtual Role? Role { get; set; } = null!;

    }

}


