

namespace HospitalManagment.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Login
    {
        [Required(AllowEmptyStrings = true, ErrorMessage = "Enter Email Address.")]
        [EmailAddress]
        [StringLength(50)]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Enter Password.")]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 6,ErrorMessage ="Incorrect Password")]
        [Display(Name = "Password: ")]
        public string Password { get; set; }
    }
}