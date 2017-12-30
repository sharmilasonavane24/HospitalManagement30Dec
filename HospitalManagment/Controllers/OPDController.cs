using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HospitalManagment.Models;
using System.Globalization;
using HospitalManagment.CustomValidation;
using System.Text;

namespace HospitalManagment.Controllers
{
    [UserValidation]
    [HandleError]
    public class OPDController : Controller
    {

        [HttpGet]
        public ActionResult OPD(int PatientId)
        {
            if (string.IsNullOrEmpty(Convert.ToString(PatientId)))
            {
                return View("Search");
            }
            Models.OPD opd = new Models.OPD();
            using (HospitalEntities ent = new HospitalEntities())
            {
                //var listTypeOfCheckup = (from chekup in ent.TypeofCheckUps
                //                         select new { chekup.TypeofCheckUpId, chekup.CheckupName }).ToList();
                //TempData["TDTypeOfCheckup"] = new SelectList(listTypeOfCheckup, "TypeofCheckUpId", "CheckupName");

                var getPaientDetails = (from tbl in ent.People
                                        where tbl.PersonId == PatientId
                                        select new
                                        {
                                            tbl.BirthDate,
                                            tbl.Firstname,
                                            tbl.MiddleName,
                                            tbl.lastName,
                                            tbl.Religion,
                                            tbl.ReferredBy,
                                            tbl.AdharCardNumber,
                                            tbl.Profession,
                                            tbl.Gender,
                                            tbl.Height
                                        }).FirstOrDefault();
                var contact = (from test in ent.PersonDetails
                               where test.PersonID == PatientId
                               select new { test.ContactID }).FirstOrDefault();
                var address = (from con in ent.Contacts
                               where con.ContactId == contact.ContactID
                               select con).FirstOrDefault();

                var lastOPDNumber = (from opdnumber in ent.OPDs
                                     where opdnumber.OPDDate.Value.Month == DateTime.Now.Month && opdnumber.OPDDate.Value.Year == DateTime.Now.Year
                                     orderby opdnumber.OPDId descending
                                     select opdnumber.OPDNumber).FirstOrDefault();
                if (lastOPDNumber == null)
                {
                    opd.MonthOPDNo = string.Concat(DateTime.Now.Year + "/" + DateTime.Now.Month + "/1");
                }
                else
                {
                    string[] split = lastOPDNumber.Split('/');
                    opd.MonthOPDNo = string.Concat(DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + Convert.ToString(Convert.ToInt32(split.Last()) + 1));
                }

                opd.Age = GetAge(getPaientDetails.BirthDate);
                opd.PatientFullName = string.Join(" ", getPaientDetails.Firstname, getPaientDetails.MiddleName, getPaientDetails.lastName);
                opd.PersonId = Convert.ToInt32(PatientId);
                opd.Gender = getPaientDetails.Gender;
                opd.Occupation = getPaientDetails.Profession;
                opd.ReferredBy = getPaientDetails.ReferredBy;
                opd.Address = string.Concat(address.StreetName, " ,", address.City, " ,", address.District, " ,", address.State);
                opd.Mobile = address.ContactNumber;
                opd.Height = Convert.ToInt32(getPaientDetails.Height);
                opd.history = new Models.History();
                var history = (from his in ent.Histories
                               where his.PersonId == PatientId
                               select his).FirstOrDefault();
                HospitalManagment.Models.History _history = new Models.History();
                if (history != null)
                {
                    _history.Abortions = Convert.ToInt32(history.Abortions);
                    _history.AllergyDetails = history.AllergyDetails;
                    _history.ChiefComplains = history.ChiefComplains;
                    _history.CurrentCycle = history.CurrentCycles;
                    _history.EDD = history.EDD.Date.ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US")); ;
                    _history.EDDCorrectedByUSG = Convert.ToDateTime(history.EDDCorrectedByUSG).Date.ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                    _history.FirstTTInjection = Convert.ToDateTime(history.FirstTTInjection).Date.ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                    _history.Gravidity = Convert.ToInt32(history.Gravidity);
                    _history.HighRiskFactor = history.HighRiskFactor;
                    _history.HistoryId = history.HistoryId;
                    _history.LivingChildren = Convert.ToInt32(history.LivingChildren);
                    _history.LMP = history.LMP.Date.ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                    _history.MenoPause = Convert.ToInt32(history.Menopause);
                    _history.Menorche = Convert.ToInt32(history.Menorch);
                    _history.ObstetricHistory = history.ObstetricHistory;
                    _history.Parity = Convert.ToInt32(history.Parity);
                    _history.PersonId = Convert.ToInt32(history.PersonId);
                    _history.PositiveFindings = history.PositiveFindings;
                    _history.Reminder = history.Reminder;
                    _history.SecondTTInjection = Convert.ToDateTime(history.SecondTTInjection).Date.ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                }
                else
                {
                    _history.HistoryId = 0;
                    _history.PersonId = PatientId;
                }
                opd.history = _history;
                TempData["History"] = _history;

                var TypeOfMedicine = (from medicineType in ent.TypeOfMedcines select medicineType).ToList();

                TempData["TypeOfMedicine"] = new SelectList(TypeOfMedicine, "TypeOfMedicineId", "TypeName");

                var listMedicineNames = (from medicineName in ent.MedcineNames select medicineName).ToList();
                MedcineName medcineName = new MedcineName();
                //  medcineName.TypeOfMedcine.TypeOfMedicineId
                medcineName.MedcineName1 = "Other";
                medcineName.MedicineWeight = 0;
                var a = (from md in ent.TypeOfMedcines
                         where md.TypeName.Equals("Other", StringComparison.InvariantCultureIgnoreCase)
                         select new { md }).FirstOrDefault();
                medcineName.TypeOfMedcine = new TypeOfMedcine();
                medcineName.TypeOfMedcine.TypeOfMedicineId = a.md.TypeOfMedicineId;
                listMedicineNames.Add(medcineName);
                TempData["MedicineNames"] = new SelectList(listMedicineNames, "MedcineNamesId", "MedcineName1");
            }
            return View(opd);
        }

        [HttpPost]
        public ActionResult OPD(Models.OPD opd, string submit)
        {
            switch (submit)
            {
                case "Verify OPD Details":
                    ViewBag.MyValue = 0;
                    if (ModelState.IsValid)
                    {
                        using (HospitalEntities ent = new HospitalEntities())
                        {
                            OPD patientOPD = new HospitalManagment.OPD();
                        }
                        ModelState.AddModelError("Error", "OPD details saved successfully!");

                        return View(opd);
                    }
                    else
                    {
                        var errors = ModelState.Values.SelectMany(v => v.Errors);
                        StringBuilder strError = new StringBuilder();
                        foreach (var item in errors)
                        {
                            strError.Append(item.ErrorMessage);
                        }
                        ModelState.AddModelError("Error", strError.ToString());

                        return View("OPD", opd);
                    }


                case "Save History":
                    using (HospitalEntities ent = new HospitalEntities())
                    {
                        History patientHistory = new HospitalManagment.History();
                        patientHistory.EDD = Convert.ToDateTime(((string[])opd.history.EDD)[0]);
                        patientHistory.EDDCorrectedByUSG = Convert.ToDateTime(((string[])opd.history.EDDCorrectedByUSG)[0]);
                        patientHistory.FirstTTInjection = Convert.ToDateTime(((string[])opd.history.FirstTTInjection)[0]);
                        patientHistory.SecondTTInjection = Convert.ToDateTime(((string[])opd.history.SecondTTInjection)[0]);
                        patientHistory.LMP = Convert.ToDateTime(((string[])opd.history.LMP)[0]);
                        patientHistory.HighRiskFactor = opd.history.HighRiskFactor;
                        patientHistory.PositiveFindings = opd.history.PositiveFindings;
                        patientHistory.PersonId = opd.PersonId;
                        patientHistory.Reminder = opd.history.Reminder;
                        patientHistory.AllergyDetails = opd.history.AllergyDetails;
                        patientHistory.ChiefComplains = opd.history.ChiefComplains;
                        patientHistory.CurrentCycles = opd.history.CurrentCycle;
                        patientHistory.Menopause = opd.history.MenoPause;
                        patientHistory.Menorch = opd.history.Menorche;
                        patientHistory.ObstetricHistory = opd.history.ObstetricHistory;
                        patientHistory.Parity = opd.history.Parity;
                        patientHistory.Gravidity = opd.history.Gravidity;
                        patientHistory.LivingChildren = opd.history.LivingChildren;
                        patientHistory.Abortions = opd.history.Abortions;
                        ent.Histories.Add(patientHistory);
                        ent.SaveChanges();
                    }
                    ModelState.AddModelError("Error", "History details saved successfully!");
                    ViewBag.MyValue = 1;
                    return View(opd);

                case "Save Prescription":
                    using (HospitalEntities ent = new HospitalEntities())
                    {
                        foreach (var item in opd.prscriptionList)
                        {
                            if (item.PrescriptionID <= 0)
                            {
                                MedcineName medcineName = new MedcineName();
                                if (item.NameOfMedicine.Equals("Other", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    TypeOfMedcine typeOfMedcine = new TypeOfMedcine();
                                    typeOfMedcine = (from ty in ent.TypeOfMedcines
                                                     where ty.TypeName == item.TypeOfMedicine
                                                     select ty).FirstOrDefault();

                                    medcineName.MedicineWeight = item.Weight;
                                    medcineName.MedcineName1 = item.newmedicine;
                                    medcineName.TypeOfMedicineId = typeOfMedcine.TypeOfMedicineId;
                                    ent.MedcineNames.Add(medcineName);
                                    ent.SaveChanges();
                                    item.NameOfMedicine = Convert.ToString(medcineName.MedcineNamesId);
                                }
                                else
                                {
                                    medcineName = (from medi in ent.MedcineNames
                                                   where medi.MedcineName1 == item.NameOfMedicine
                                                   select medi).FirstOrDefault();
                                }
                                Prescription prescription = new Prescription();

                                prescription.MedcineNamesId = medcineName.MedcineNamesId;   //Convert.ToInt32(item.NameOfMedicine);
                                prescription.Dosage = Convert.ToString(item.Dosage);
                                prescription.NumberOfDays = item.NumberOfDays;
                                prescription.OpdID = opd.OPDID;
                                prescription.CreatedDateTime = DateTime.Now;
                                string[] array = new string[] { "Other", "Ointment", "Creame", "Syrup" };
                                var isContains = array.Where(a => a.Equals(item.TypeOfMedicine, StringComparison.InvariantCultureIgnoreCase));
                                if (isContains != null && isContains.Count() > 0)
                                {
                                    prescription.Quantity = "1";
                                }
                                else
                                {
                                    prescription.Quantity = Convert.ToString(item.NumberOfDays * item.Dosage);
                                }
                                ent.Prescriptions.Add(prescription);
                                ent.SaveChanges();
                                item.PrescriptionID = prescription.PrescriptionID;
                            }
                        }

                    }
                    ModelState.AddModelError("Error", "Prescription saved successfully!");
                    ViewBag.MyValue = 3;
                    return View(opd);

                case "Save Examination":
                    using (HospitalEntities ent = new HospitalEntities())
                    {

                        HospitalManagment.OPD oPD = new HospitalManagment.OPD();
                        var person = (from pers in ent.People
                                                           where pers.PersonId == opd.PersonId
                                                           select pers
                                                            ).FirstOrDefault();
                        if (opd.OPDID > 0)
                        {
                            oPD = (from opddeatails in ent.OPDs
                                   where opddeatails.OPDId == opd.OPDID
                                   select opddeatails).FirstOrDefault();
                        }
                        oPD.BP = opd.clinicalExamination.BP;
                        oPD.CNS = opd.clinicalExamination.CNS;
                        oPD.OPDDate = DateTime.Now;
                        oPD.PA = opd.clinicalExamination.PA;
                        oPD.PS = opd.clinicalExamination.PS;
                        oPD.Pulse = opd.clinicalExamination.Pulse;
                        oPD.PV = opd.clinicalExamination.PV;
                        oPD.Rs = opd.clinicalExamination.Rs;
                        oPD.CVS = opd.clinicalExamination.CVS;
                        oPD.Weight = opd.clinicalExamination.CurrentWeight;
                        person.Height = Convert.ToString(opd.Height);
                        oPD.BMI = opd.clinicalExamination.BMI;
                        oPD.OtherGeneralFindings = opd.clinicalExamination.OtherGenFindings;
                        oPD.TypeofCheckUp = 1;
                        oPD.OPDNumber = opd.MonthOPDNo;
                        oPD.PersonID = opd.PersonId;
                        if (opd.OPDID <= 0)
                        {
                            ent.OPDs.Add(oPD);
                        }
                        ent.SaveChanges();
                        opd.OPDID = oPD.OPDId;

                    }
                    ModelState.AddModelError("Error", "Examination details saved successfully!");
                    ViewBag.MyValue = 2;
                    return View(opd);

                case "Print Prescription":
                    return View("PrintPrescription", opd);
            }
            return View();
        }

        public PartialViewResult History(Models.History history, string submit)
        {
            if (ModelState.IsValid)
            { }
            return PartialView();
        }

        public ActionResult Search(SearchPatient searchPatient, AllPatientDetails allPatientDetails)
        {
            List<AllPatientDetails> lstPatientdetails = new List<AllPatientDetails>();

            using (HospitalEntities ent = new HospitalEntities())
            {
                int person = Convert.ToInt32(searchPatient.RegistrationNo);
                //
                var showDetails = (from patientDetail in ent.PersonDetails
                                   join per in ent.People on patientDetail.PersonID equals per.PersonId
                                   join opd in ent.OPDs on per.PersonId equals opd.PersonID into test
                                   from opd1 in test.DefaultIfEmpty()
                                   join cont in ent.Contacts on patientDetail.ContactID equals cont.ContactId
                                   //where per.Firstname.Contains(searchPatient.FirstName)
                                   //|| cont.ContactNumber.Contains(searchPatient.ContactNumber)
                                   //|| per.PersonId.Equals(person)
                                   //|| t.OPDNumber.Contains(searchPatient.OPDNO)

                                   select new { per, cont, opd1 }).ToList().Distinct();


                if (searchPatient != null && searchPatient.FirstName != null)
                {
                    showDetails = showDetails.Where(a => a.per.Firstname.Contains(searchPatient.FirstName));
                }

                if (searchPatient != null && searchPatient.ContactNumber != null)
                {
                    showDetails = showDetails.Where(a => a.cont.ContactNumber.Contains(searchPatient.ContactNumber));
                }

                if (person > 0) { showDetails = showDetails.Where(a => a.per.PersonId.Equals(person)); }

                if (searchPatient != null && searchPatient.OPDNO != null)
                {
                    showDetails = showDetails.Where(a => a.opd1.OPDNumber.Contains(searchPatient.OPDNO));
                }

                showDetails = showDetails.Distinct();
                if (showDetails != null && showDetails.Count() > 0)
                {
                    foreach (var item in showDetails)
                    {

                        AllPatientDetails patientDetails = new AllPatientDetails();

                        patientDetails.Address = string.Concat(item.cont.StreetName, ",", item.cont.City);
                        patientDetails.Age = GetAge(item.per.BirthDate);
                        patientDetails.BirthDate = item.per.BirthDate.Date.ToString("dd-M-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                        patientDetails.MobileNumber = item.cont.ContactNumber;
                        patientDetails.patientName = string.Concat(item.per.Firstname, " ", item.per.MiddleName, " ", item.per.lastName);
                        patientDetails.Profession = item.per.Profession;
                        patientDetails.ContactId = item.cont.ContactId;
                        patientDetails.PatientId = item.per.PersonId;
                        if (!lstPatientdetails.Any(a => a.PatientId.Equals(item.per.PersonId)))
                        {
                            lstPatientdetails.Add(patientDetails);
                        }
                    }
                }
            }
            //ModelState.AddModelError("Error", "Person details saved successfully!");

            return View(lstPatientdetails.Distinct());
            ///return View();
        }

        [HttpPost]
        public string DeleteMedicine(int prescriptionID, OPD opd)
        {
            using (HospitalEntities ent = new HospitalEntities())
            {
                Prescription prescription = new Prescription();
                prescription = (from pre in ent.Prescriptions
                                where pre.PrescriptionID == prescriptionID
                                select pre).FirstOrDefault();

                ent.Prescriptions.Remove(prescription);
                ent.SaveChanges();
                return "Delete";
            }
        }

        private Decimal GetAge(DateTime birthDate)
        {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(birthDate).Ticks).Year - 1;
            DateTime PastYearDate = birthDate.AddYears(Years);
            Decimal Months = 0;
            if (birthDate.ToString() != "1/1/0001 12:00:00 AM")
            {
                for (int i = 1; i <= 12; i++)
                {
                    string strMonths;
                    if (PastYearDate.AddMonths(i) == Now)
                    {
                        strMonths = "0." + i.ToString();
                        Months = Convert.ToDecimal(strMonths);
                        break;
                    }
                    else if (PastYearDate.AddMonths(i) >= Now)
                    {
                        strMonths = "0." + i.ToString();
                        Months = Convert.ToDecimal(strMonths);
                        break;
                    }
                }
            }
            else
            {
                return 0;
            }
            Decimal retval = Years + Months;


            return retval;
        }
    }
}
