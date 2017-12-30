using System.ComponentModel.DataAnnotations;

namespace HospitalManagment.Models
{
    public class ClinicalExamination
    {
        [Required]
        [Display(Name = "Blood Pressure: ")]
        public string BP { get; set; }
         
        [Required]
        [Display(Name = "Pulse: ")]
        public int Pulse { get; set; }

        [Display(Name = "Weight: (Kgs)")]
        public decimal CurrentWeight { get; set; }

        [Display(Name = "Provisional Diagnosis: ")]
        public string positiveFidings { get; set; }

        [Display(Name = "RS: ")]
        public string Rs { get; set; }

        [Display(Name = "CVS: ")]
        public string CVS { get; set; }

        [Display(Name = "P/A: ")]
        public string PA { get; set; }

        [Display(Name = "P/S: ")]
        public string PS { get; set; }

        [Display(Name = "P/V: ")]
        public string PV { get; set; }

        [Display(Name = "CNS: ")]
        public string CNS { get; set; }

        [Display(Name = "BMI: ")]
        public string BMI { get; set; }

        [Display(Name = "Other General Findings: ")]
        public string OtherGenFindings { get; set; }
    }
}