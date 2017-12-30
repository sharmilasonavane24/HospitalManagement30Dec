using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagment.Models
{
    public class OPD
    {
        public int OPDID { get; set; }

        [DisplayName("OPD No:")]
        public string MonthOPDNo { get; set; }

        [DisplayName("Regstration No:")]
        public int PersonId { get; set; }

        [Display(Name = "Patient Full Name: ")]
        public string PatientFullName { get; set; }       

        [Display(Name = "Age: ")]
        public decimal Age { get; set; }

        [Display(Name = "Religion: ")]
        public string Religion { get; set; }

        [Display(Name = "Address: ")]
        public string Address { get; set; }

        [Display(Name = "Occupation: ")]
        public string Occupation { get; set; }

        [Display(Name = "Referred By: ")]
        public string ReferredBy { get; set; }

        [Display(Name = "Gender: ")]
        public string Gender { get; set; }
         
        [Display(Name = "Mobile No: ")]
        public string Mobile { get; set; }

        [Display(Name = "Height (Cm): ")]
        public int? Height { get; set; }
        //[Display(Name = "Allergy Details: ")]
        //public string AllergyDetails { get; set; }

        // [Required]
        //public string History { get; set; }



        //public string Reminder { get; set; }

        // [Required]
        [Display(Name = "Type Of Checkup: ")]
        public int TypeOfCheckup { get; set; }

        

      


        public History history { get; set; }

        public List<Prescription> prscriptionList { get; set; }

        public ClinicalExamination clinicalExamination { get; set; }
    }


}