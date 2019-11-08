using CRMP.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMP.Web.Controllers
{
    public class ReclamationAdminController : Controller
    {
        private ReclamationService RS;

        public ReclamationAdminController()
        {
            RS = new ReclamationService();
        }
        // GET: ReclamationAdmin
        public ActionResult Index()
        {
            return View(RS.GetAll());
        }



        // GET: ReclamationAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReclamationAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReclamationAdmin/Create
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

        // GET: ReclamationAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReclamationAdmin/Edit/5
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

        // GET: ReclamationAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReclamationAdmin/Delete/5
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
