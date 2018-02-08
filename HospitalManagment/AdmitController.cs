using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagment.Models;

namespace HospitalManagment.Controllers
{
    public class AdmitController : Controller
    {
        // GET: Admit
        public ActionResult Index()
        {
			using (HospitalEntities ent = new HospitalEntities())
			{
				var ipdNumber = (from ipd in ent.IPDs
								 select ipd.IpdNumber
								 ).FirstOrDefault();
				AdmitPatient admitPatient = new AdmitPatient();
			//	admitPatient.IPDNumber = ( )
			return View(admitPatient);
			}
        }


    }
}