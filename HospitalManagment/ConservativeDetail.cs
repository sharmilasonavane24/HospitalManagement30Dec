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
    
    public partial class ConservativeDetail
    {
        public int ConservativeDetailId { get; set; }
        public Nullable<int> IPDId { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<int> DayNumber { get; set; }
    
        public virtual IPD IPD { get; set; }
    }
}
