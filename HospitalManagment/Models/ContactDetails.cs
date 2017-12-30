

namespace HospitalManagment.Models
{
    using BusinessLayer;
    using System.ComponentModel.DataAnnotations;
    using HospitalManagment.CommanValidation;

    public class ContactDetails : IContact
    {
        [ScaffoldColumn(false)]
        public int ContactId
        { get; set; }


        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Email Address: ", Order = 2)]
        public string EmailId { get; set; }

        // [Required(ErrorMessage = "Enter Mobile number.")]
        [Display(Name = "Mobile Number: ")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, MinimumLength = 10)]
        [PhoneNumberValidation]
        public string ContactNumber { get; set; }

        // [Required(ErrorMessage = "Enter Street Name.")]
        [StringLength(20, MinimumLength = 5)]
        public string StreetName { get; set; }

        // [Required(ErrorMessage = "Enter City Name.")]
        [StringLength(20, MinimumLength = 4)]
        public string City { get; set; }

        // [Required(ErrorMessage = "Enter Taluka Name.")]
        [StringLength(20, MinimumLength = 4)]
        public string Taluka { get; set; }

        // [Required(ErrorMessage = "Enter District Name.")]
        [StringLength(20, MinimumLength = 4)]
        public string District { get; set; }

        //[Required(ErrorMessage = "Enter Pincode.")]
        [StringLength(6, MinimumLength = 6)]
        public string Pincode { get; set; }

        //[Required(ErrorMessage = "Enter District Name.")]
        //[StringLength(6, MinimumLength = 6)]
        [ScaffoldColumn(false)]
        public string State { get; set; }

        //[Required(ErrorMessage = "Enter District Name.")]
        //[StringLength(6, MinimumLength = 6)]
        [ScaffoldColumn(false)]
        public string Country { get; set; }
    }
}