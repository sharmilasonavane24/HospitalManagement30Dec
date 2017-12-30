using System.ComponentModel.DataAnnotations;

namespace HospitalManagment.Models
{
    public class Prescription
    {
        // public int OpdID { get; set; }
        [Display(Name = "Medicine:")]
        public string NameOfMedicine { get; set; }

        [Display(Name = "Dosage:")]
        public int Dosage { get; set; }

        [Display(Name = "Type:")]
        public string TypeOfMedicine { get; set; }

        [Display(Name = "Weight:")]
        public decimal Weight { get; set; }

        [Display(Name = "Days:")]
        public int NumberOfDays { get; set; }

        [Display(Name = "Advise:")]
        public string Comment { get; set; }

        [Display(Name = "Management Plan:")]
        public string ManagementPlan { get; set; }

        [Display(Name = "New Medicine:")]
        public string newmedicine { get; set; }

        //[Required]
        //[Display(Name = "Advice: ")]
        //public string Advice { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Next Opointment Date: ")]
        public object NextOpointmentDate { get; set; }

        public int PrescriptionID { get; set; }
    }
}