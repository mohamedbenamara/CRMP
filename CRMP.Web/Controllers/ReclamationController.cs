using CRMP.Domain.Entities;
using CRMP.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace CRMP.Web.Controllers
{
    public class ReclamationController : Controller
    {
        private ReclamationService RS;
        public ReclamationController()
        {
            RS = new ReclamationService();
        }
        // GET: Reclamation
        public ActionResult Index()
        {
            return View(RS.GetAll().Where(rec=>rec.userId== User.Identity.Name));
        }

        // GET: Reclamation
        public ActionResult afficherType()
        {
            List<string> TyperecList = new List<string>(3);
            TyperecList.Add("technical branch");
            TyperecList.Add("financial branch");
            TyperecList.Add("relationelle");
            return View();

        }

        // GET: Reclamation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reclamation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reclamation/Create
        [HttpPost]
        public ActionResult Create(Reclamation reclam)
        {
            try
            {
                // TODO: Add insert logic here
                reclam.userId = User.Identity.Name;
                User.Identity.GetUserId();
;

                reclam.etatRec = "Open";
                RS.Update(reclam);
               
                RS.Add(reclam);
                
                RS.Commit();

             
              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reclamation/Edit/5
        public ActionResult Edit(int id)
        {
           
            return View();
        }

        // POST: Reclamation/Edit/5
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

        // GET: Reclamation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reclamation/Delete/5
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
