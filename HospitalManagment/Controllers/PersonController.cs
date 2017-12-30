using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagment.Models;
using System.Text;

using HospitalManagment.CustomValidation;
using System.Globalization;

namespace HospitalManagment.Controllers
{
    [UserValidation]
    public class PersonController : Controller
    {
        //
        // GET: /Person/
        [HttpGet]
        public ActionResult AddPatientDetails()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SavePatientDetails(PersonDetails person)
        {
            if (ModelState.IsValid)
            {
                using (HospitalEntities ent = new HospitalEntities())
                {
                    Person patientDetails = new HospitalManagment.Person();
                    string birthDate = ((string[])person.BirthDate)[0];
                    var isPersonExists = (from patient in ent.People
                                          where person.Firstname.Equals(patient.Firstname, StringComparison.InvariantCultureIgnoreCase)
                                          && person.LastName.Equals(patient.lastName, StringComparison.InvariantCultureIgnoreCase)
                                          && person.MiddleName.Equals(patient.MiddleName, StringComparison.InvariantCultureIgnoreCase)
                                          && (birthDate).Equals(patient.BirthDate.ToString())
                                          select patient).SingleOrDefault();
                    if (isPersonExists == null)
                    {
                        patientDetails.Firstname = person.Firstname;
                        patientDetails.lastName = person.LastName;
                        patientDetails.AdharCardNumber = Convert.ToDecimal(person.AdharCardNumber);
                        if (!string.IsNullOrEmpty(((string[])person.BirthDate)[0]))
                        {
                            patientDetails.BirthDate = Convert.ToDateTime(((string[])person.BirthDate)[0]);
                            patientDetails.Age = GetAge(Convert.ToDateTime(((string[])person.BirthDate)[0]));
                        }
                        if (person.Age != null && person.Age > 0)
                        {
                            patientDetails.Age = Convert.ToDecimal(person.Age);
                        }
                        patientDetails.Gender = Enum.GetName(typeof(BusinessLayer.Gender), person.Gender);
                        patientDetails.Height = Convert.ToString(person.Height);
                        patientDetails.MiddleName = person.MiddleName;
                        patientDetails.Profession = person.Profession;
                        patientDetails.RegisterDate = DateTime.Now;



                        patientDetails.ReferredBy = person.ReferredBy;
                        patientDetails.Religion = person.Religion;
                        ent.People.Add(patientDetails);
                        int personId = ent.SaveChanges();
                        // ent.People
                        // ent.Pe.Add(patientDetails);
                        ent.SaveChanges();
                        int patientId = patientDetails.PersonId;
                        Dictionary<string, string> dictionary = new Dictionary<string, string>();
                        dictionary.Add("LastName", person.LastName);
                        dictionary.Add("MiddleName", person.MiddleName);
                        dictionary.Add("patientId", patientId.ToString());
                        TempData["Details"] = dictionary;
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Person details already exists !");

                        return View("AddPatientDetails", person);
                    }
                }
                return this.RedirectToAction("AddSpouseDetails");
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

                return View("AddPatientDetails");
            }


        }


        [HttpGet]
        public ActionResult AddSpouseDetails()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            PersonDetails person = new PersonDetails();
            if (TempData["Details"] != null)
            {
                data = TempData["Details"] as Dictionary<string, string>;

                string firstName, lastName;
                data.TryGetValue("MiddleName", out firstName);
                data.TryGetValue("LastName", out lastName);
                person.Firstname = firstName;
                person.LastName = lastName;

                TempData.Keep();
            }
            return View("AddSpouseDetails", person);
        }

        [HttpPost]
        public ActionResult SaveSpouseDetails([Bind(Exclude = "Height,BirthDate")] PersonDetails person)
        {
            ModelState.Remove("BirthDate");
            if (ModelState.IsValid)
            {
                using (HospitalEntities ent = new HospitalEntities())
                {

                    var isPersonExists = (from patient in ent.People
                                          where person.Firstname.Equals(patient.Firstname, StringComparison.InvariantCultureIgnoreCase)
                                          && person.LastName.Equals(patient.lastName, StringComparison.InvariantCultureIgnoreCase)
                                          && person.MiddleName.Equals(patient.MiddleName, StringComparison.InvariantCultureIgnoreCase)

                                          select patient).SingleOrDefault();
                    if (isPersonExists == null)
                    {
                        Person patientDetails = new HospitalManagment.Person();

                        patientDetails.Firstname = person.Firstname;
                        patientDetails.lastName = person.LastName;
                        patientDetails.AdharCardNumber = Convert.ToDecimal(person.AdharCardNumber);
                        //patientDetails.BirthDate = Convert.ToDateTime(person.BirthDate);
                        patientDetails.Gender = Enum.GetName(typeof(BusinessLayer.Gender), person.Gender);
                        //patientDetails.Height = person.Height;
                        patientDetails.MiddleName = person.MiddleName;
                        patientDetails.Profession = person.Profession;
                        patientDetails.RegisterDate = DateTime.Now;

                        ent.People.Add(patientDetails);
                        ent.SaveChanges();
                        // ent.People
                        // ent.Pe.Add(patientDetails);

                        int spouseId = patientDetails.PersonId;

                        Dictionary<string, string> data = new Dictionary<string, string>();
                        if (TempData["Details"] != null)
                        {
                            data = TempData["Details"] as Dictionary<string, string>;

                            data.Add("spouseId", spouseId.ToString());
                            TempData["Details"] = data;
                            //TempData.Keep();
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Person details already exists !");

                        return View("AddSpouseDetails", person);
                    }
                }
                return this.RedirectToAction("AddChildDetails");
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

                return View("AddSpouseDetails", person);
            }
        }

        [HttpGet]
        public ActionResult AddChildDetails()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            PersonDetails person = new PersonDetails();
            if (TempData["Details"] != null)
            {
                data = TempData["Details"] as Dictionary<string, string>;

                string middleName, lastName;
                data.TryGetValue("MiddleName", out middleName);
                data.TryGetValue("LastName", out lastName);
                person.MiddleName = middleName;
                person.LastName = lastName;

                TempData.Keep();
            }
            return View("AddChildDetails", person);

        }

        [HttpPost]
        public ActionResult SaveChildDetails([Bind(Exclude = "AdharCardNumber,Height,Profession")] PersonDetails person, string submit)
        {
            ModelState.Remove("Profession");
            if (ModelState.IsValid)
            {
                using (HospitalEntities ent = new HospitalEntities())
                {
                    Person patientDetails = new HospitalManagment.Person();

                    string birthDate = ((string[])person.BirthDate)[0];
                    var isPersonExists = (from patient in ent.People
                                          where person.Firstname.Equals(patient.Firstname, StringComparison.InvariantCultureIgnoreCase)
                                          && person.LastName.Equals(patient.lastName, StringComparison.InvariantCultureIgnoreCase)
                                          && person.MiddleName.Equals(patient.MiddleName, StringComparison.InvariantCultureIgnoreCase)
                                          && (birthDate).Equals(patient.BirthDate.ToString())
                                          select patient).SingleOrDefault();
                    if (isPersonExists == null)
                    {
                        patientDetails.Firstname = person.Firstname;
                        patientDetails.lastName = person.LastName;
                        //patientDetails.AdharCardNumber = Convert.ToDecimal(person.AdharCardNumber);
                        if (!string.IsNullOrEmpty(((string[])person.BirthDate)[0]))
                        {
                            patientDetails.BirthDate = Convert.ToDateTime(((string[])person.BirthDate)[0]);

                            patientDetails.Age = GetAge(Convert.ToDateTime(((string[])person.BirthDate)[0]));
                        }
                        if (person.Age != null && person.Age > 0)
                        {
                            patientDetails.Age = Convert.ToDecimal(person.Age);
                        }
                        patientDetails.BirthDate = Convert.ToDateTime(((string[])person.BirthDate)[0]);
                        patientDetails.Gender = Enum.GetName(typeof(BusinessLayer.Gender), person.Gender);
                        //patientDetails.Height = person.Height;
                        patientDetails.MiddleName = person.MiddleName;
                        patientDetails.Profession = person.Profession;
                        patientDetails.RegisterDate = DateTime.Now;

                        ent.People.Add(patientDetails);

                        ent.SaveChanges();
                        int childId = patientDetails.PersonId;
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        if (TempData["Details"] != null)
                        {
                            data = TempData["Details"] as Dictionary<string, string>;
                            if (!data.ContainsKey("childId"))
                            {
                                data.Add("childId", childId.ToString());
                            }
                            else
                            {
                                string commaSeprateCurrentChildIds = string.Empty;
                                data.TryGetValue("childId", out commaSeprateCurrentChildIds);
                                data["childId"] = string.Concat(commaSeprateCurrentChildIds, ",", childId);
                            }
                            TempData["Details"] = data;
                            //TempData.Keep();
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Person details already exists !");

                        return View("AddChildDetails", person);
                    }
                }

                if (submit.Equals("Save Child Details", StringComparison.InvariantCultureIgnoreCase))
                {
                    return this.RedirectToAction("AddChildDetails"); // this is to add next child details
                }
                return this.RedirectToAction("AddContactDetails");
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

                return View("AddChildDetails", person);
            }
        }

        [HttpGet]
        public ActionResult AddContactDetails()
        {
            return View();
        }


        public ActionResult SaveContactDetail(ContactDetails contact)
        {
            string patientId = string.Empty, spouseId = string.Empty, childId = string.Empty;
            if (ModelState.IsValid)
            {
                using (HospitalEntities ent = new HospitalEntities())
                {
                    Contact contactDetails = new HospitalManagment.Contact();

                    contactDetails.City = contact.City;
                    contactDetails.ContactNumber = contact.ContactNumber;
                    //patientDetails.AdharCardNumber = Convert.ToDecimal(person.AdharCardNumber);
                    contactDetails.Country = "India";// Convert.ToDateTime(((string[])person.BirthDate)[0]);
                    contactDetails.District = contact.District;// Enum.GetName(typeof(BusinessLayer.Gender), person.Gender);
                    //patientDetails.Height = person.Height;
                    contactDetails.EmailId = contact.EmailId;
                    contactDetails.Pincode = contact.Pincode;
                    contactDetails.State = "Maharashtra";
                    contactDetails.StreetName = contact.StreetName;
                    contactDetails.Taluka = contact.Taluka;
                    ent.Contacts.Add(contactDetails);

                    ent.SaveChanges();
                    int contactId = contactDetails.ContactId;
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    if (TempData["Details"] != null)
                    {

                        data = TempData["Details"] as Dictionary<string, string>;
                        data.Add("contactId", contactId.ToString());

                        data.TryGetValue("patientId", out patientId);
                        data.TryGetValue("spouseId", out spouseId);
                        data.TryGetValue("childId", out childId);
                        childId = string.IsNullOrEmpty(childId) ? "0" : childId;
                        PersonDetail allDetails = new PersonDetail();
                        allDetails.PersonTypeID = 1;
                        allDetails.ContactID = contactId;
                        allDetails.SpouseID = Convert.ToInt32(spouseId);
                        allDetails.ChildIDs = (childId);
                        allDetails.PersonID = Convert.ToInt32(patientId);
                        ent.PersonDetails.Add(allDetails);
                        ent.SaveChanges();
                        int allDetailsId = allDetails.PersonDetailsId;
                        data.Add("personDetailsId", allDetailsId.ToString());
                        TempData["Details"] = data;
                        //TempData.Keep();
                    }

                }
                int PatientId = Convert.ToInt32(patientId);
                return this.RedirectToAction("OPD", "OPD", new { PatientId = PatientId });
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

                return View("AddContactDetails", contact);
            }

        }

        public ActionResult CancelForm()
        {
            ViewBag.Message = "The operation was cancelled!";
            return RedirectToAction("Search", "OPD");

        }

        public ActionResult ShowAllDetails(AllPatientDetails patientDetails)
        {

            Dictionary<string, string> data = TempData["Details"] as Dictionary<string, string>;
            if (data != null)
            {
                List<AllPatientDetails> lstPatientdetails = new List<AllPatientDetails>();
                using (HospitalEntities ent = new HospitalEntities())
                {
                    string personDetailId;
                    data.TryGetValue("personDetailsId", out personDetailId);
                    int id = Convert.ToInt32(personDetailId);
                    var showDetails = (from patientDetail in ent.PersonDetails
                                       join per in ent.People on patientDetail.PersonID equals per.PersonId
                                       join cont in ent.Contacts on patientDetail.ContactID equals cont.ContactId
                                       where patientDetail.PersonDetailsId == id
                                       select new { per, cont }).FirstOrDefault();

                    patientDetails.Address = string.Concat(showDetails.cont.StreetName, " ", showDetails.cont.City);
                    patientDetails.Age = showDetails.per.Age;
                    patientDetails.BirthDate = showDetails.per.BirthDate.Date.ToString("MM-dd-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                    patientDetails.MobileNumber = showDetails.cont.ContactNumber;
                    patientDetails.patientName = string.Concat(showDetails.per.Firstname, " ", showDetails.per.MiddleName, " ", showDetails.per.lastName);
                    patientDetails.Profession = showDetails.per.Profession;
                    patientDetails.ContactId = showDetails.cont.ContactId;
                    patientDetails.PatientId = showDetails.per.PersonId;
                    patientDetails.PatientDetailsId = personDetailId;
                }
                ModelState.AddModelError("Error", "Person details saved successfully!");
                lstPatientdetails.Add(patientDetails);
                return View(lstPatientdetails);
            }
            else
            {

                ModelState.AddModelError("Error", "Something went wrong please contact admin!");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private Decimal GetAge(DateTime birthDate)
        {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(birthDate).Ticks).Year - 1;
            DateTime PastYearDate = birthDate.AddYears(Years);
            Decimal Months = 0;
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

            Decimal retval = Years + Months;


            return retval;
        }
    }
}
