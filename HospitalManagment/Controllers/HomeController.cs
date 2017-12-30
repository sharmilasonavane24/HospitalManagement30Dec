using HospitalManagment.CustomValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagment.Controllers
{
    [UserValidation]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public string Index()
        {
            return "Thank you ....!";
        }

    }
}
