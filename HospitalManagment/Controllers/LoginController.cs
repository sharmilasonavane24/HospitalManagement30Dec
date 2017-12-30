using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagment.Models;
using System.Web.Security;

namespace HospitalManagment.Controllers
{
    [HandleError()]
    public class LoginController : Controller
    {

        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LoginDetails(Login login)
        {
            if (ModelState.IsValid)
            {

                using (HospitalEntities ent = new HospitalEntities())
                {

                    var userDetails = (from user in ent.Users
                                       where user.EmailId.Equals(login.Email) &&
                                       user.Password.Equals(login.Password) &&
                                       user.IsActive == true
                                       select user).SingleOrDefault();
                    if (userDetails != null)
                    {
                        Session["UserDetails"] = userDetails;

                        return this.RedirectToAction("Search", "OPD");
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Entered email or password is incorrect.");
                        return View("Login");
                    }
                }
            }
            return View("Login");
        }


        public ActionResult Logout()
        {
            Session["UserDetails"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
