namespace HospitalManagment.Models
{
    using System.ComponentModel;
    using System;
    using System.Collections.Generic;

    public class AllPatientDetails
    {
        [DisplayName("Regstration No")]
        public int PatientId { get; set; }

        [DisplayName("Patient Name")]
        public string patientName { get; set; }

        [DisplayName("Age")]
        public Decimal Age { get; set; }

        [DisplayName("Birth Date")]
        public string BirthDate { get; set; }

        [DisplayName("Profession")]
        public string Profession { get; set; }

        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("All OPD Details")]
        public List<OPD> oPD { get; set; }

        [DisplayName("All Prescription Details")]
        public List<Prescription> prescription { get; set; }

        public int ContactId { get; set; }

        public string PatientDetailsId { get; set; }

        [DisplayName("Any OPD No")]
        public string AnyOpdNo { get; set; }
    }
}