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
    
    public partial class LabourDetail
    {
        public int LabourDetailId { get; set; }
        public int IPDId { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string DeliveryNote { get; set; }
    
        public virtual IPD IPD { get; set; }
    }
}
