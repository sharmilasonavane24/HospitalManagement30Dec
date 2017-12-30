namespace HospitalManagment.Models
{
    using BusinessLayer;
    using System.ComponentModel.DataAnnotations;
    using HospitalManagment.CustomValidation;

    public class PersonDetails : IPerson
    {
        [ScaffoldColumn(false)]
        [Display(Name = "Registration No: ")]
        public int PersonId
        {
            get;
            set;
        }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Enter First Name.")]
        [Display(Name = "First Name: ")]
        public string Firstname
        {
            get;
            set;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Last Name.")]
        [Display(Name = "Last Name: ")]
        public string LastName
        {
            get;
            set;
        }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Enter Middle Name.")]
        [Display(Name = "Middle Name: ")]
        public string MiddleName
        {
            get;
            set;
        }

        //[Display(Name = "Gender: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Select Gender.")]
        public Gender Gender
        {
            get;
            set;
        }

        [Display(Name = "Date of Birth: ")]
        //[Range(typeof(System.DateTime), "1/1/1900", System.DateTime.Now.ToString(), ErrorMessage = "Value for   must be between   and  ")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[PastDateAllow(MinAge = 0, MaxAge = 91250)]
        public object BirthDate
        {
            get;
            set;
        }

        [Display(Name = "Age: ")]
        public decimal? Age
        { get; set; }

        [Display(Name = "Height (Cm): ")]
        public int? Height
        { get; set; }

        [ScaffoldColumn(false)]
        public string RegisterDate
        { get; set; }

        [Display(Name = "Adhar Card Number: ")]
        [StringLength(maximumLength: 12, MinimumLength = 0)]
        public string AdharCardNumber
        { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Enter Profession.")]
        [Display(Name = "Profession: ")]
        public string Profession
        { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Religion.")]
        [Display(Name = "Religion: ")]
        public string Religion
        { get; set; }


        [Display(Name = "Refferred By: ")]
        public string ReferredBy
        { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Select personType.")]
        //[Display(Name = "Profession: ")] 
        // not necessary to show on UI when we are creating link will pass the type like Patient , Spouse or Child 
        [ScaffoldColumn(false)]
        public PersonTypes PersonType
        {
            get;
            set;
        }
    }
}