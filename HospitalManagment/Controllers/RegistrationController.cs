using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagment.Models;
using System.Text;
using HospitalManagment.CustomValidation;
//using System.Web.Http;

namespace HospitalManagment.Controllers
{
    //[UserValidation]
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Registration/Details/5

        public ActionResult RegisterationDetails(int id)
        {
            return View();
        }

        //
        // GET: /Registration/Create

        public ActionResult Registeration(Registration register)
        {
            ModelState.Remove("CreatedDate");
            ModelState.Remove("IsActive");
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                using (HospitalEntities ent = new HospitalEntities())
                {
                    var userDetails = (from user in ent.Users
                                       where user.EmailId.Equals(register.Email)
                                       select user).SingleOrDefault();

                    if (userDetails == null)
                    {
                        User user = new HospitalManagment.User();
                        user.EmailId = register.Email;
                        user.FirstName = register.FirstName;
                        user.LastName = register.LastName;
                        user.Password = register.Password;
                        user.PhoneNumber = register.ContactNumber;
                        user.UserType = Enum.GetName(typeof(BusinessLayer.UserTypes), register.UserType);
                        var type = Enum.Parse(typeof(BusinessLayer.UserTypes), register.UserType.ToString());
                        user.IsActive = true;
                        user.CreatedDate = DateTime.Now;
                        ent.Users.Add(user);
                        ent.SaveChanges();
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Email " + register.Email + " allready exist!");
                        return View("Index");
                    }
                }
                return this.RedirectToAction("Login", "Login");
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

                return View("Index");
            }

        }



        //
        // POST: /Registration/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Registration/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Registration/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Registration/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Registration/Delete/5

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
    }
}
