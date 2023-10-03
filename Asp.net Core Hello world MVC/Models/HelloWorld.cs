using System;
//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;


namespace Asp.net_Core_Hello_world_MVC.Models
{
    public class HelloWorld
    {
        //The Error message will throw automatically, if you want custom error, you can use the below ErrorMessage method.
        [Required(ErrorMessage = "Age is required")]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Must be Alphabets and spaces only")]
        public string Name { get; set; }

        [Required]
        [Range(18, 65, ErrorMessage = "Age must be 18 to 65")]
        public Nullable<int> Age { get; set; }

        [Display(Name="Date of Birth")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> DateOfBirth { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}

