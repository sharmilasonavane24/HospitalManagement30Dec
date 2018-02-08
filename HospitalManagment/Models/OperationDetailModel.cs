 using System;
    using System.Collections.Generic;
namespace HospitalManagment.Models
{
      
    public   class OperationDetailModel
    {    
        public int OperationDetailId { get; set; }
        public int? IPDId { get; set; }
        public DateTime? OperationDate { get; set; }
        public int? TypeOfOperationId { get; set; }
        public string OpeationNote { get; set; }
        public string PostOpDirection { get; set; }
        public IPD IPD { get; set; }
        public TypeOfOperation TypeOfOperation { get; set; }
        public ICollection<TreatmentChart> TreatmentCharts { get; set; }
    }
}
