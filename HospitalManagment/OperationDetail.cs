//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalManagment
{
    using System;
    using System.Collections.Generic;
    
    public partial class OperationDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OperationDetail()
        {
            this.TreatmentCharts = new HashSet<TreatmentChart>();
        }
    
        public int OperationDetailId { get; set; }
        public Nullable<int> IPDId { get; set; }
        public Nullable<System.DateTime> OperationDate { get; set; }
        public int TypeOfOperationId { get; set; }
        public string OpeationNote { get; set; }
        public string PostOpDirection { get; set; }
    
        public virtual IPD IPD { get; set; }
        public virtual TypeOfOperation TypeOfOperation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TreatmentChart> TreatmentCharts { get; set; }
    }
}
