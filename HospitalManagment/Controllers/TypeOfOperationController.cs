using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagment.Controllers
{
    public class TypeOfOperationController : Controller
    {
        // GET: TypeOfOperation
        public ActionResult TypeOfOperation()
        {
            return View();
        }

        // GET: TypeOfOperation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TypeOfOperation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeOfOperation/Create
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

        // GET: TypeOfOperation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TypeOfOperation/Edit/5
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

        // GET: TypeOfOperation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TypeOfOperation/Delete/5
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
