

namespace HospitalManagment.Models
{
    using System.ComponentModel.DataAnnotations;
    using BusinessLayer;
    using HospitalManagment.CommanValidation;

    public partial class Registration : IRegistration
    {
        public int UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter First Name.")]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Last Name.")]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Email Address.")]
        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Email Address: ")]
        public string Email { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Mobile number.")]
            [Display(Name = "Mobile Number: ")]
            [DataType(DataType.PhoneNumber)]
            [StringLength(10, MinimumLength = 10)]
            [PhoneNumberValidation]
        public string ContactNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Password.")]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 6)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Confirm Password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [StringLength(10, MinimumLength = 6)]
        [Display(Name = "Confirm Password: ")]
        public string ConfirmPassword { get; set; }

        [ScaffoldColumn(false)]
        public string PasswordSalt { get; set; }


        [ScaffoldColumn(false)]
        [Display(Name = "User Type: ")]
        public UserTypes UserType { get; set; }

        [ScaffoldColumn(false)]       
        public System.DateTime CreatedDate { get; set; }

        [ScaffoldColumn(false)]       
        public bool IsActive { get; set; }

        //public string IPAddress { get; set; }
    }
}