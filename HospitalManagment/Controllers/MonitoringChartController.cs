using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagment.Controllers
{
    public class MonitoringChartController : Controller
    {
        // GET: MonitoringChart
        public ActionResult MonitoringChart()
        {
            return View();
        }

        // GET: MonitoringChart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MonitoringChart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonitoringChart/Create
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

        // GET: MonitoringChart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MonitoringChart/Edit/5
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

        // GET: MonitoringChart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MonitoringChart/Delete/5
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
