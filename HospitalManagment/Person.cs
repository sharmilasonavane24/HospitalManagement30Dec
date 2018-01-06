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
    
    public partial class Person
    {
        public Person()
        {
            this.Investigations = new HashSet<Investigation>();
            this.OPDs = new HashSet<OPD>();
            this.PersonDetails = new HashSet<PersonDetail>();
            this.Histories = new HashSet<History>();
        }
    
        public int PersonId { get; set; }
        public string Firstname { get; set; }
        public string lastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Height { get; set; }
        public System.DateTime RegisterDate { get; set; }
        public Nullable<decimal> AdharCardNumber { get; set; }
        public string Profession { get; set; }
        public decimal Age { get; set; }
        public string Religion { get; set; }
        public string ReferredBy { get; set; }
        public string FatherOrSpouseProfession { get; set; }
    
        public virtual ICollection<Investigation> Investigations { get; set; }
        public virtual ICollection<OPD> OPDs { get; set; }
        public virtual ICollection<PersonDetail> PersonDetails { get; set; }
        public virtual ICollection<History> Histories { get; set; }
    }
}
