using System.ComponentModel.DataAnnotations;

namespace HospitalManagment.Models
{
    public class Investigations
    {
        [Display(Name = "Investigation Id: ")]
        public int InvestigationId { get; set; }
        [Display(Name = "Opd Id: ")]
        public int OpdId { get; set; }
        [Display(Name = "Blood Group: ")]
        public string BloodGroup { get; set; }
        [Display(Name = "HB: ")]
        public string HB { get; set; }
        [Display(Name = "RBS: ")]
        public string RBS { get; set; }
        [Display(Name = "HIV & II: ")]
        public string HIVNII { get; set; }
        [Display(Name = "HBS Avg: ")]
        public string HBSAvg { get; set; }
        [Display(Name = "VDRL: ")]
        public string VDRL { get; set; }
        [Display(Name = "Urine RM: ")]
        public string UrineRM { get; set; }
        [Display(Name = "Sr. Creat: ")]
        public string SrCreat { get; set; }
        [Display(Name = "Sr. Urea: ")]
        public string SrUrea { get; set; }
        [Display(Name = "Sr. TSH: ")]
        public string SrTSH { get; set; }
        [Display(Name = "HSG: ")]
        public string HSG { get; set; }
        [Display(Name = "Semen Analysis: ")]
        public string SemenAnalysis { get; set; }
        [Display(Name = "USG: ")]
        public string USG { get; set; }
        [Display(Name = "Other: ")]
        public string Other { get; set; }
        [Display(Name = "All Attachments in One PDF: ")]
        public string AllAttachmentinOnePDF { get; set; }
    }
}