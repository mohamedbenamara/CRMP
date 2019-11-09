using CRMP.Domain.Entities;
using CRMP.Services.Services;
using CRMP.Web.Models;
using Rotativa.MVC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CRMP.Web.Controllers
{
    public class StoreController : Controller
    {
        private StoreService SS;
        public StoreController()
        {
            SS = new StoreService();
        }

        // GET: Store
        public ActionResult Index()
        {
           
            return View(SS.GetAll());
        }
        
        public ActionResult IndexPDF()
        {
            return View(SS.GetAll());
        }
        //@HtmlAction.Link("Nom du button","nom de la fonction dans le controlleur","nom du controlleur");
        public ActionResult Export()
        {
            return new ActionAsPdf("IndexPDF")
            {
                FileName = Server.MapPath("~/Content/PDF/Liste.pdf")
            };
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            return View(SS.GetById(id));
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(Store store, HttpPostedFileBase file)
        {
            store.storeImage = file.FileName;
            SS.Add(store);
            SS.Commit();
            var fileName = "";
            if (file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/uploads/"), file.FileName);
                file.SaveAs(path);
            }

                // TODO: Add insert logic here
               
                return RedirectToAction("Index");
            

            
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            Store s = SS.GetById(id);
            return View(s);
        }

        // POST: Store/Edit/5

        [HttpPost]
        public ActionResult Edit(Store s, HttpPostedFileBase file)
        {
            /*s.storeImage = file.FileName;
            var fileName = "";
            if (file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/uploads/"), file.FileName);
                file.SaveAs(path);
            }*/


            Store s1 = SS.GetById(s.StoreId);
            s1.storeName = s.storeName;
            s1.storeImage = s.storeImage;
            s1.storeDesc = s.storeDesc;
            s1.storeNum = s.storeNum;
            s1.Heure_ouverture = s.Heure_ouverture;
            s1.Heure_fermeture = s.Heure_fermeture;
            s1.storeaddress = s.storeaddress;

            if (ModelState.IsValid)
            {
                SS.Update(s1);
                SS.Commit();

                /* store = SS.GetById(id);
                 SS.Update(store);
                 SS.Commit();*/
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }

            return View();

        }

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View(SS.GetById(id));
        }

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Store store)
        {
            try
            {
                store = SS.GetById(id);
                SS.Delete(store);
                SS.Commit();

                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //****************************FROOOOOOOOOOOOOONT*********************************************//

        public ActionResult IndexFront()
        {
            return View(SS.GetAll());
        }

        public ActionResult DetailsFront(int id)
        {
            return View(SS.GetById(id));
        }
    }
}
