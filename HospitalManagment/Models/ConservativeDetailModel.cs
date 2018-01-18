using System;

namespace HospitalManagment.Models
{
    
    public  class ConservativeDetailModel
    {
        public int ConservativeDetailId { get; set; }
        public int? IPDId { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? DayNumber { get; set; }
    
        public   IPD IPD { get; set; }
    }
}
