

namespace HospitalManagment.CustomValidation
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FutureDateaAllowAttribute : ValidationAttribute
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(Convert.ToString(((string[])value)[0])))
                return new ValidationResult("Invalid Date!");

            //var date  = Convert.to
            var val = Convert.ToDateTime(((string[])value)[0]);

            if (Convert.ToDateTime(((string[])value)[0]) > DateTime.Now)
                return ValidationResult.Success;
            else
                return new ValidationResult("Invalid Future Date!");
            //(val.AddYears(MaxAge) > DateTime.Now);
        }
    }

    public class PastDateAllowAttribute : ValidationAttribute
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(Convert.ToString(value)))
                return new ValidationResult("Invalid Date!");

            //var date  = Convert.to
            var val = Convert.ToDateTime(((string[])value)[0]);

            if (Convert.ToDateTime(((string[])value)[0]) < DateTime.Now)
                return ValidationResult.Success;
            else
                return new ValidationResult("Invalid Past Date!");
            //(val.AddYears(MaxAge) > DateTime.Now);
        }
    }
}
