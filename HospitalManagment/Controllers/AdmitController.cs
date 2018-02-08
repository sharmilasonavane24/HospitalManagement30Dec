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
			AdmitPatient admitPatient = new AdmitPatient();
			admitPatient.IPDNumber = getIPDNumber();
			return View(admitPatient);
		}

		public string getIPDNumber()
		{
			string ipdNumber = string.Empty;
			using (HospitalEntities ent = new HospitalEntities())
			{
				ipdNumber = (from ipd in ent.IPDs
							 where ipd.AdmissionDate.Value.Month == DateTime.Now.Month
							 && ipd.AdmissionDate.Value.Year == DateTime.Now.Year
							 select ipd.IpdNumber).FirstOrDefault();
				if (!string.IsNullOrEmpty(ipdNumber))
				{
					ipdNumber = DateTime.Now.Year + "/" + DateTime.Now.Month + "/1";
				}
				else
				{
					var newNumber = Convert.ToInt32(ipdNumber.Split('/')[1]) + 1;
					ipdNumber.Split('/')[1] = newNumber.ToString();
				}
			}
			return ipdNumber;
		}
	}
}
