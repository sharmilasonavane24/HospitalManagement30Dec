using System;
using System.Collections.Generic;

namespace HospitalManagment.Models
{
  
    
    public   class IpdModel
    {
    
        public int IPDId { get; set; }
        public int TypeOfRoomAndBedId { get; set; }
        public DateTime? AdmissionDate { get; set; }
    
        public   ICollection<ConservativeDetail> ConservativeDetails { get; set; }
        public   TypeOfRoomAndBed TypeOfRoomAndBed { get; set; }
        public   ICollection<LabourDetail> LabourDetails { get; set; }
        public   ICollection<OperationDetail> OperationDetails { get; set; }
    }
}
