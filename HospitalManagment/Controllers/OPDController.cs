using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HospitalManagment.Models;
using System.Globalization;
using HospitalManagment.CustomValidation;
using System.Text;
using System.Web;
using System.IO;
using System.Threading.Tasks;

namespace HospitalManagment.Controllers
{
    [UserValidation]
    [HandleError]
    public class OPDController : Controller
    {
        //[HttpGet]
        //public ActionResult OPD()
        //{

        //    Models.OPD opd = new Models.OPD();
        //    using (HospitalEntities ent = new HospitalEntities())
        //    {
        //        var lastOPDNumber = (from opdnumber in ent.OPDs
        //                             where opdnumber.OPDDate.Value.Month == DateTime.Now.Month && opdnumber.OPDDate.Value.Year == DateTime.Now.Year
        //                             orderby opdnumber.OPDId descending
        //                             select opdnumber.OPDNumber).FirstOrDefault();
        //        if (lastOPDNumber == null)
        //        {
        //            opd.MonthOPDNo = string.Concat(DateTime.Now.Year + "/" + DateTime.Now.Month + "/1");
        //        }
        //        else
        //        {
        //            string[] split = lastOPDNumber.Split('/');
        //            opd.MonthOPDNo = string.Concat(DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + Convert.ToString(Convert.ToInt32(split.Last()) + 1));
        //        }
        //        opd.history = new Models.History();
        //        HospitalManagment.Models.History _history = new Models.History();

        //        opd.history = _history;
        //        AddDefaultMedicineName();
        //    }

        //    //return OPD(opd, "Save Examination");
        //    return View(opd);
        //}

        [HttpGet]
        public ActionResult OPD(int? PatientId)
        {
            Models.OPD opd = new Models.OPD();
            if (string.IsNullOrEmpty(Convert.ToString(PatientId)))
            {

                using (HospitalEntities ent = new HospitalEntities())
                {
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
                    opd.history = new Models.History();
                    HospitalManagment.Models.History _history = new Models.History();

                    opd.history = _history;
                    AddDefaultMedicineName();
                }

                //return OPD(opd, "Save Examination");
                return View(opd);
            }

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
                    _history.EDD = Convert.ToDateTime(history.EDD).Date.ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US")); ;
                    _history.EDDCorrectedByUSG = Convert.ToDateTime(history.EDDCorrectedByUSG).Date.ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                    _history.FirstTTInjection = Convert.ToDateTime(history.FirstTTInjection).Date.ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                    _history.Gravidity = Convert.ToInt32(history.Gravidity);
                    _history.HighRiskFactor = history.HighRiskFactor;
                    _history.HistoryId = history.HistoryId;
                    _history.LivingChildren = Convert.ToInt32(history.LivingChildren);
                    _history.LMP = Convert.ToDateTime(history.LMP).Date.ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
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
                    _history.PersonId = Convert.ToInt32(PatientId);
                }
                opd.history = _history;
                TempData["History"] = _history;

                var TypeOfMedicine = (from medicineType in ent.TypeOfMedcines select medicineType).ToList();
                var typeOfIntakeAdv = (from intakeAdvType in ent.TypeOfIntakeAdvs select intakeAdvType).ToList();

                TempData["TypeOfMedicine"] = new SelectList(TypeOfMedicine, "TypeOfMedicineId", "TypeName");
                TempData["TypeOfIntakeAdv"] = new SelectList(typeOfIntakeAdv, "TypeOfIntakeAdvId", "TypeName");
                int selectedId = 1;

                ViewBag.DefaultTypeOfIntakeAdv = new SelectList(typeOfIntakeAdv, "TypeOfIntakeAdvId", "TypeName", selectedId);
                AddDefaultMedicineName();
            }

            return OPD(opd, "Save Examination");
            //return View(opd);
        }

        [HttpPost]
        public ActionResult OPD(Models.OPD opd, string submit)
        {
            switch (submit)
            {
                case "Save Patient Details":
                    ViewBag.MyValue = 0;

                    using (HospitalEntities ent = new HospitalEntities())
                    {
                        OPD patientOPD = new HospitalManagment.OPD();

                        var _person = ent.People.Add(new Person
                        {
                            Age = opd.Age,
                            Firstname = opd.PatientFullName.Split(' ')[0],
                            MiddleName = opd.PatientFullName.Split(' ')[1],
                            lastName = opd.PatientFullName.Split(' ')[2],
                            Gender = opd.Gender,
                            Profession = opd.Occupation,
                            FatherOrSpouseProfession = opd.FatherOrSpouseProfession,
                            ReferredBy = opd.ReferredBy,
                            Religion = opd.Religion,

                        });

                        var _contact = ent.Contacts.Add(new Contact
                        {
                            City = "Phaltan",
                            ContactNumber = opd.Mobile,
                            District = "Satara",
                            Pincode = "415523",
                            State = "Maharashtra",
                            StreetName = opd.Address,
                            Taluka = "Phaltan"
                        });

                        ent.SaveChanges();

                        ent.PersonDetails.Add(new PersonDetail
                        {
                            ContactID = _contact.ContactId,
                            SpouseID = 0,
                            PersonID = _person.PersonId,
                            PersonTypeID = 1
                        });

                        ent.SaveChanges();
                        opd.PersonId = _person.PersonId;


                    }
                    ModelState.AddModelError("Error", "Patient details saved successfully!");
                    return OPD(opd, "Save Examination");




                case "Save History":
                    using (HospitalEntities ent = new HospitalEntities())
                    {

                        History patientHistory = new HospitalManagment.History();
                        if (opd.history != null && opd.history.HistoryId > 0)
                        {
                            patientHistory = (from histry in ent.Histories
                                              where histry.HistoryId == opd.history.HistoryId
                                              select histry).FirstOrDefault();
                        }
                        if (opd.history.EDD != null && !string.IsNullOrEmpty(Convert.ToString(opd.history.EDD)) && !string.IsNullOrEmpty(((string[])opd.history.EDD)[0]))
                        { patientHistory.EDD = Convert.ToDateTime(((string[])opd.history.EDD)[0]); }
                        if (opd.history.EDDCorrectedByUSG != null && !string.IsNullOrEmpty(Convert.ToString(opd.history.EDDCorrectedByUSG)) && !string.IsNullOrEmpty(((string[])opd.history.EDDCorrectedByUSG)[0]))
                        { patientHistory.EDDCorrectedByUSG = Convert.ToDateTime(((string[])opd.history.EDDCorrectedByUSG)[0]); }
                        if (opd.history.FirstTTInjection != null && !string.IsNullOrEmpty(Convert.ToString(opd.history.FirstTTInjection)) && !string.IsNullOrEmpty((opd.history.FirstTTInjection)))
                        { patientHistory.FirstTTInjection = Convert.ToString((opd.history.FirstTTInjection)); }
                        if (opd.history.SecondTTInjection != null && !string.IsNullOrEmpty(Convert.ToString(opd.history.SecondTTInjection)) && !string.IsNullOrEmpty((opd.history.SecondTTInjection)))
                        { patientHistory.SecondTTInjection = Convert.ToString((opd.history.SecondTTInjection)); }
                        if (opd.history.LMP != null && !string.IsNullOrEmpty(Convert.ToString(opd.history.LMP)) && !string.IsNullOrEmpty(((string[])opd.history.LMP)[0]))
                        { patientHistory.LMP = Convert.ToDateTime(((string[])opd.history.LMP)[0]); }
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
                        if (opd.history != null && opd.history.HistoryId <= 0)
                        {
                            ent.Histories.Add(patientHistory);

                        }
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
                            DateTime? _NextAppoinmentDate = null;
                            if (opd.prscriptionList[0].NextOpointmentDate != null && !string.IsNullOrEmpty(Convert.ToString(opd.prscriptionList[0].NextOpointmentDate)) &&
                                !string.IsNullOrEmpty(((string[])opd.prscriptionList[0].NextOpointmentDate)[0]))
                            {
                                _NextAppoinmentDate = Convert.ToDateTime(((string[])opd.prscriptionList[0].NextOpointmentDate)[0]);
                            }
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
                                    //item.NameOfMedicine = Convert.ToString(medcineName.MedcineNamesId);
                                    AddDefaultMedicineName();

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
                                prescription.comments = item.Comment;
                                prescription.ManagementPlan = item.ManagementPlan;
                                prescription.NextAppoinmentDate = _NextAppoinmentDate;
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
                                prescription.TypeOfIntakeAdvId = (from medi in ent.TypeOfIntakeAdvs
                                                                  where medi.TypeName == item.TypeOfIntakeAdv
                                                                  select medi.TypeOfIntakeAdvId).FirstOrDefault();


                                ent.Prescriptions.Add(prescription);
                                ent.SaveChanges();
                                item.PrescriptionID = prescription.PrescriptionID;
                            }
                        }

                    }
                    ModelState.AddModelError("Error", "Prescription saved successfully!");
                    ViewBag.MyValue = 4;
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
                        oPD.OPDDate = DateTime.Now;
                        // person.Height = Convert.ToString(opd.Height);
                        oPD.TypeofCheckUp = 1;
                        oPD.OPDNumber = opd.MonthOPDNo;
                        oPD.PersonID = opd.PersonId;
                        if (opd.clinicalExamination != null)
                        {
                            oPD.BP = opd.clinicalExamination.BP;
                            oPD.CNS = opd.clinicalExamination.CNS;
                            oPD.PA = opd.clinicalExamination.PA;
                            oPD.PS = opd.clinicalExamination.PS;
                            oPD.Pulse = opd.clinicalExamination.Pulse;
                            oPD.PV = opd.clinicalExamination.PV;
                            oPD.Rs = opd.clinicalExamination.Rs;
                            oPD.CVS = opd.clinicalExamination.CVS;
                            oPD.Weight = Convert.ToDecimal(opd.clinicalExamination.CurrentWeight);
                            oPD.BMI = opd.clinicalExamination.BMI;
                            oPD.OtherGeneralFindings = opd.clinicalExamination.OtherGenFindings;
                            ModelState.AddModelError("Error", "Examination details saved successfully!");
                            ViewBag.MyValue = 2;
                        }

                        if (opd.OPDID <= 0)
                        {
                            ent.OPDs.Add(oPD);
                            ViewBag.MyValue = 0;
                        }
                        ent.SaveChanges();
                        opd.OPDID = oPD.OPDId;

                    }

                    return View(opd);

                case "Print Prescription":
                    if (opd.prscriptionList != null && opd.prscriptionList.Count > 0)
                        return View("PrintPrescription", opd);
                    else
                    {
                        ModelState.AddModelError("Error", "Please save prescription!");
                        return View();
                    }
            }
            return View(opd);
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

        public ActionResult ActionName(int OpdId)
        {
            try
            {
                // ElementViewModel model = new ElementViewModel();
                Investigations model = new Investigations();
                model.OpdId = OpdId;
                // model.List = new List<ElementViewModelItem> { new ElementViewModelItem { IdElement = 1 }, new ElementViewModelItem { IdElement = 2 } };
                return PartialView("_InvestigationsPartialView", model);
            }
            catch (Exception ex)
            {
                return null;
                //ex.Message.ToString();
            }


        }


        //HttpPostedFileBase file,

        [HttpPost]
        public void UploadFile(HttpPostedFileBase AllAttachmentinOnePDF)
        {
            try
            {
                if (Path.GetExtension(AllAttachmentinOnePDF.FileName).Contains("pdf"))
                {

                    using (HospitalEntities ent = new HospitalEntities())
                    {
                        Investigation _investigation = new Investigation();

                        if (AllAttachmentinOnePDF != null && AllAttachmentinOnePDF.ContentLength > 0)
                        {
                            string DateWsepath = Server.MapPath("~/" + DateTime.Today.ToString("ddMMyyyy") + "");
                            if (!System.IO.Directory.Exists(DateWsepath))
                            {
                                System.IO.Directory.CreateDirectory(DateWsepath);
                            }

                            string _FileName = Path.GetFileName(AllAttachmentinOnePDF.FileName);
                            string _path = Path.Combine(DateWsepath, _FileName);

                            TempData["AllAttachmentinOnePDFPath"] = _path;
                            AllAttachmentinOnePDF.SaveAs(_path);
                            ViewBag.MyValue = 3;
                        }

                    }
                    ViewBag.Message = "File Uploaded Successfully!!";
                }
                else
                {
                    throw new Exception("Invalid file format");
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = "File upload failed!!";

            }


        }

        [HttpPost]
        public int SaveInvestigations(Investigations investigations)
        {
            try
            {
                using (HospitalEntities ent = new HospitalEntities())
                {
                    Investigation _investigation = new Investigation();
                    if (investigations.InvestigationId > 0)
                    {
                        _investigation = (from investigat in ent.Investigations
                                          where investigat.InvestigationId == investigations.InvestigationId
                                          select investigat).FirstOrDefault();
                    }


                    var path = TempData["AllAttachmentinOnePDFPath"];
                    if (path != null && !string.IsNullOrEmpty(Convert.ToString(path)))
                        _investigation.AllAttachmentinOnePDF = System.IO.File.ReadAllBytes(Convert.ToString(path));

                    _investigation.PersonId = investigations.PersonId;
                    _investigation.BloodGroup = investigations.BloodGroup;
                    _investigation.HB = investigations.HB;
                    _investigation.HBSAvg = investigations.HBSAvg;
                    _investigation.HIV_II = investigations.HIVNII;
                    _investigation.HSG = investigations.HSG;
                    _investigation.OpdId = investigations.OpdId;
                    _investigation.Other = investigations.Other;
                    _investigation.RBS = investigations.RBS;
                    _investigation.SemenAnalysis = investigations.SemenAnalysis;
                    _investigation.Sr_Creat = investigations.SrCreat;
                    _investigation.Sr_TSH = investigations.SrTSH;
                    _investigation.Sr_Urea = investigations.SrUrea;
                    _investigation.UrineRM = investigations.UrineRM;
                    _investigation.USG = investigations.USG;
                    _investigation.VDRL = investigations.VDRL;
                    if (investigations.InvestigationId <= 0)
                    {
                        _investigation.CreatedDateTime = DateTime.Now;
                        ent.Investigations.Add(_investigation);

                    }

                    ent.SaveChanges();
                    investigations.InvestigationId = _investigation.InvestigationId;

                }
                ViewBag.MyValue = 3;
                ViewBag.Message = "File Uploaded Successfully!!";

            }
            catch (Exception ex)
            {
                ViewBag.Message = "File upload failed!!";

            }
            return investigations.InvestigationId;
        }

        public ActionResult OpdSavedAttachmet(int InvestigationId)
        {
            string ToSaveFileTo = Server.MapPath("~\\Report.pdf");

            using (HospitalEntities ent = new HospitalEntities())
            {
                var data = (from abc in ent.Investigations
                            where abc.InvestigationId == InvestigationId
                            select abc.AllAttachmentinOnePDF
                            ).FirstOrDefault();
                if (data != null)
                {
                    byte[] fileData = (byte[])data;

                    using (System.IO.FileStream fs = new System.IO.FileStream(ToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                    {

                        using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))

                        {
                            bw.Write(fileData);

                            bw.Close();
                        }
                    }
                    FileStream fst = new FileStream(ToSaveFileTo, FileMode.Open, FileAccess.Read);
                    return File(fst, "application/pdf");

                }
            }

            //ModelState.AddModelError("Error", "No attachment founds!");
            return Content("No attachment founds!");
        }

        [HttpGet]
        public ActionResult GetPreviousInvestigations(int personId)
        {
            List<Investigations> listInvestigations = new List<Investigations>();
            using (HospitalEntities ent = new HospitalEntities())
            {
                var _Investigations = (from investigation in ent.Investigations
                                       where investigation.PersonId == personId
                                       select investigation).ToList();

                foreach (var item in _Investigations)
                {
                    Investigations investigations = new Investigations();
                    investigations.BloodGroup = item.BloodGroup;
                    investigations.HB = item.HB;
                    investigations.HBSAvg = item.HBSAvg;
                    investigations.HIVNII = item.HIV_II;
                    investigations.HSG = item.HSG;
                    investigations.InvestigationId = item.InvestigationId;
                    investigations.OpdId = item.OpdId;
                    investigations.Other = item.Other;
                    investigations.PersonId = item.PersonId;
                    investigations.RBS = item.RBS;
                    investigations.SemenAnalysis = item.SemenAnalysis;
                    investigations.SrCreat = item.Sr_Creat;
                    investigations.SrTSH = item.Sr_TSH;
                    investigations.SrUrea = item.Sr_Urea;
                    investigations.UrineRM = item.UrineRM;
                    investigations.USG = item.USG;
                    investigations.VDRL = item.VDRL;
                    investigations.CreatedDate = item.CreatedDateTime;
                    listInvestigations.Add(investigations);
                }


                return PartialView("_PreviousInvestigationsDetails", listInvestigations);
            }
        }

        [HttpGet]
        public ActionResult GetPreviousClinicalExaminations(int personId)
        {
            List<ClinicalExamination> listClinicalExaminations = new List<ClinicalExamination>();
            using (HospitalEntities ent = new HospitalEntities())
            {
                var _ClinicalExaminations = (from examinations in ent.OPDs
                                             where examinations.PersonID == personId
                                             select examinations).ToList();

                foreach (var item in _ClinicalExaminations)
                {
                    if (!string.IsNullOrEmpty(item.BMI) || !string.IsNullOrEmpty(item.BP) || !string.IsNullOrEmpty(item.CNS) ||
                        !string.IsNullOrEmpty(item.CVS) || !string.IsNullOrEmpty(item.OtherGeneralFindings) || item.Weight > 0)
                    {
                        ClinicalExamination clinicalExamination = new ClinicalExamination();
                        clinicalExamination.BMI = item.BMI;
                        clinicalExamination.BP = item.BP;
                        clinicalExamination.CNS = item.CNS;
                        clinicalExamination.CurrentWeight = item.Weight;
                        clinicalExamination.CVS = item.CVS;
                        clinicalExamination.OtherGenFindings = item.OtherGeneralFindings;
                        clinicalExamination.PA = item.PA;
                        clinicalExamination.PS = item.PS;
                        clinicalExamination.Pulse = item.Pulse;
                        clinicalExamination.PV = item.PV;
                        clinicalExamination.Rs = item.Rs;
                        clinicalExamination.dateTime = Convert.ToDateTime(item.OPDDate);

                        listClinicalExaminations.Add(clinicalExamination);
                    }
                }


                return PartialView("_PreviousClinicalEaminations", listClinicalExaminations);
            }
        }

        [HttpGet]
        public ActionResult GetPreviousPrescriptionDetails(int personId)
        {
            List<HospitalManagment.Models.Prescription> listPrescription = new List<Models.Prescription>();
            using (HospitalEntities ent = new HospitalEntities())
            {
                var _Prescriptions = (from examinations in ent.Prescriptions
                                      join opd in ent.OPDs on examinations.OpdID equals opd.OPDId
                                      join medName in ent.MedcineNames on examinations.MedcineNamesId equals medName.MedcineNamesId
                                      join typemedicine in ent.TypeOfMedcines on medName.TypeOfMedicineId equals typemedicine.TypeOfMedicineId
                                      join adv in ent.TypeOfIntakeAdvs.DefaultIfEmpty() on examinations.TypeOfIntakeAdvId equals adv.TypeOfIntakeAdvId
                                      where opd.PersonID == personId
                                      select new { examinations, medName, adv, typemedicine, opd }).ToList();

                foreach (var item in _Prescriptions)
                {
                    Models.Prescription prescription = new Models.Prescription();
                    prescription.Comment = item.examinations.comments;
                    prescription.Dosage = Convert.ToInt32(item.examinations.Dosage);
                    prescription.ManagementPlan = item.examinations.ManagementPlan;
                    prescription.NameOfMedicine = item.medName.MedcineName1;
                    prescription.NextOpointmentDate = Convert.ToString(item.examinations.NextAppoinmentDate);
                    prescription.NumberOfDays = item.examinations.NumberOfDays;
                    prescription.PrescriptionID = item.examinations.PrescriptionID;
                    prescription.TypeOfIntakeAdv = item.adv.TypeName;
                    prescription.TypeOfMedicine = item.typemedicine.TypeName;
                    prescription.OpdID = item.opd.OPDNumber;
                    listPrescription.Add(prescription);
                }


                return PartialView("previousPrescriptionDetails", listPrescription);
            }
        }

        [HttpPost]
        public void DeleteExistingMedicine(string MedicineId)
        {
            int Id = Convert.ToInt32(MedicineId);
            using (HospitalEntities ent = new HospitalEntities())
            {
                MedcineName DelMedicineNames = (from medName in ent.MedcineNames
                                                where medName.MedcineNamesId == Id
                                                select medName).FirstOrDefault();

                if (DelMedicineNames != null)
                {
                    DelMedicineNames.IsDeleted = true;
                    DelMedicineNames.DeletedDateTime = DateTime.Now;
                    ent.SaveChanges();
                }
                Task.Factory.StartNew(() => AddDefaultMedicineName());
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

        private void AddDefaultMedicineName()
        {
            using (HospitalEntities ent = new HospitalEntities())
            {
                var listMedicineNames = (from medicineName in ent.MedcineNames
                                         where medicineName.IsDeleted == false
                                         select medicineName).ToList();
                MedcineName medcineName = new MedcineName();
                //  medcineName.TypeOfMedcine.TypeOfMedicineId
                medcineName.MedcineName1 = "Other";
                medcineName.MedicineWeight = -1;
                var a = (from md in ent.TypeOfMedcines
                         where md.TypeName.Equals("Other", StringComparison.InvariantCultureIgnoreCase)
                         select new { md }).FirstOrDefault();
                medcineName.TypeOfMedcine = new TypeOfMedcine();
                medcineName.TypeOfMedcine.TypeOfMedicineId = a.md.TypeOfMedicineId;
                listMedicineNames.Add(medcineName);
                TempData["MedicineNames"] = new SelectList(listMedicineNames, "MedcineNamesId", "MedcineName1");
                var TypeOfMedicine = (from medicineType in ent.TypeOfMedcines select medicineType).ToList();
                var typeOfIntakeAdv = (from intakeAdvType in ent.TypeOfIntakeAdvs select intakeAdvType).ToList();

                TempData["TypeOfMedicine"] = new SelectList(TypeOfMedicine, "TypeOfMedicineId", "TypeName");
                TempData["TypeOfIntakeAdv"] = new SelectList(typeOfIntakeAdv, "TypeOfIntakeAdvId", "TypeName");
                int selectedId = 1;

                ViewBag.DefaultTypeOfIntakeAdv = new SelectList(typeOfIntakeAdv, "TypeOfIntakeAdvId", "TypeName", selectedId);
            }
        }
    }
}
