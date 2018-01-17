using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagment.Controllers
{
    public class LabourDetailController : Controller
    {
        // GET: LabourDetail
        public ActionResult LabourDetail()
        {
            return View();
        }

        // GET: LabourDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LabourDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LabourDetail/Create
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

        // GET: LabourDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LabourDetail/Edit/5
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

        // GET: LabourDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LabourDetail/Delete/5
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
