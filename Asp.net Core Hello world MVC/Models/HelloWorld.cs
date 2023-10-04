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

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> DateOfBirth { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "Phone no:")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        public string Phone { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }


        [Display(Name = "Feedback")]
        [StringLength(100)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Must be Alphabets and spaces only")]
        public string Feedback { get; set; }

        public MaritalStatus EnumMaritalStatus { get; set; }

    }

    //When we know that our options will not change, we can use enum
    //In DB it will be stored as values and not text
    public enum MaritalStatus
    {
        NeverMarried = 1, Married = 2, Widowed = 3, Divorced = 4, Other = 5
    }
}

