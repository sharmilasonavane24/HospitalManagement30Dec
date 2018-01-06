//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalManagment
{
    using System;
    using System.Collections.Generic;
    
    public partial class History
    {
        public int HistoryId { get; set; }
        public string Reminder { get; set; }
        public string AllergyDetails { get; set; }
        public string FirstTTInjection { get; set; }
        public string SecondTTInjection { get; set; }
        public Nullable<System.DateTime> LMP { get; set; }
        public Nullable<System.DateTime> EDD { get; set; }
        public System.DateTime EDDCorrectedByUSG { get; set; }
        public Nullable<int> PersonId { get; set; }
        public string HighRiskFactor { get; set; }
        public string ObstetricHistory { get; set; }
        public string PositiveFindings { get; set; }
        public Nullable<int> Gravidity { get; set; }
        public Nullable<int> Parity { get; set; }
        public Nullable<int> LivingChildren { get; set; }
        public Nullable<int> Abortions { get; set; }
        public Nullable<int> Menorch { get; set; }
        public Nullable<int> Menopause { get; set; }
        public string ChiefComplains { get; set; }
        public string CurrentCycles { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
