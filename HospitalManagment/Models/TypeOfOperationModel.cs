using System.Collections.Generic;
namespace HospitalManagment.Models
{
  
    
    public class TypeOfOperationModel
    {
    
        public int TypeOfOperationId { get; set; }
        public string TypeName { get; set; }
    
        public ICollection<OperationDetail> OperationDetails { get; set; }
    }
}
