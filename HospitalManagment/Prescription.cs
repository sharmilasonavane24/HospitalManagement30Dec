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
    
    public partial class Prescription
    {
        public int PrescriptionID { get; set; }
        public int OpdID { get; set; }
        public string Dosage { get; set; }
        public string Quantity { get; set; }
        public int NumberOfDays { get; set; }
        public string comments { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public int MedcineNamesId { get; set; }
        public Nullable<System.DateTime> NextAppoinmentDate { get; set; }
        public string ManagementPlan { get; set; }
        public int TypeOfIntakeAdvId { get; set; }
    
        public virtual MedcineName MedcineName { get; set; }
        public virtual OPD OPD { get; set; }
        public virtual TypeOfIntakeAdv TypeOfIntakeAdv { get; set; }
    }
}
