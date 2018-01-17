using System;

namespace HospitalManagment.Models
{
    public class LabourDetailModel
    {
        public int LabourDetailId { get; set; }
        public int? IPDId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryNote { get; set; }
        public IPD IPD { get; set; }
    }
}
