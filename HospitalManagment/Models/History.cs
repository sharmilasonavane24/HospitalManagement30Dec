namespace HospitalManagment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class History
    {
        public int HistoryId { get; set; }
        public int PersonId { get; set; }

        [Display(Name = "Reminder: ")]
        public string Reminder { get; set; }

        [Display(Name = "Past/Personal/Family History")]
        public string AllergyDetails { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "First TT Injection: ")]
       // [Required]
        public object FirstTTInjection { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Second TT Injection: ")]
       // [Required]
        public object SecondTTInjection { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "LMP: ")]
       // [Required]
        public object LMP { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "EDD: ")]
       // [Required]
        public object EDD { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "EDD Corrected By USG: ")]
        // [Required]
        public object EDDCorrectedByUSG { get; set; }

        [Display(Name = "Obstetric History: ")]
        public string ObstetricHistory { get; set; }

        [Display(Name = "High Risk Factor:")]
        public string HighRiskFactor { get; set; }

        [Display(Name = "Positive Findings:")]
        public string PositiveFindings { get; set; }

        [Display(Name = "Current Cycle:")]
        public string CurrentCycle { get; set; }

        [Display(Name = "Menarche:")]
        public int Menorche { get; set; }

        [Display(Name = "Menopause:")]
        public int MenoPause { get; set; }

        [Display(Name = "G:")]
        [Range(minimum: 0, maximum: 20)]
        public int Gravidity { get; set; }

        [Display(Name = "P:")]
        [Range(minimum: 0, maximum: 20)]
        public int Parity { get; set; }

        [Display(Name = "L:")]
        [Range(minimum: 0, maximum: 20)]
        public int LivingChildren { get; set; }

        [Display(Name = "A:")]
        [Range(minimum: 0, maximum: 20)]
        public int Abortions { get; set; }

        [Display(Name = "Chief Complains:")]
        public string ChiefComplains { get; set; }
    }
}