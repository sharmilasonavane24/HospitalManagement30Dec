

 

namespace HospitalManagment.CommanValidation
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using  PhoneNumbers;
    using HospitalManagment.CustomValidation;

    public class PhoneNumberValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {

                var instance = PhoneNumberUtil.GetInstance();
                PhoneNumber phoneNumber = instance.Parse((string)value, "IN");
                if (instance.IsValidNumber(phoneNumber))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessages.PhoneNumberErrorMsg);
                }

            }
            catch (Exception)
            {
                return new ValidationResult(ErrorMessages.PhoneNumberErrorMsg);
            }
        }
    }
}