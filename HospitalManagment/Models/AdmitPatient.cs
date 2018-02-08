using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagment.Models
{
	public class AdmitPatient
	{
		public int TypeOfAdmit { get; set; }
		public string IPDNumber { get; set; }
		public DateTime ConsentForm { get; set; }
		public int RoomNBed { get; set; }
		public int TypeofOperation { get; set; }
		public DateTime? OperationDataTime { get; set; } 
		public string OperationNote { get; set; }
	}
}