using CRMP.Domain.Entities;
using CRMP.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
           ViewBag.totale= RS.NbrRec();
          //  int totale = RS.NbrRec();
            
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
            
            ViewBag.days = Math.Truncate(RS.diffDay(id));
            var rec = RS.GetById(id);
            if (rec == null)
            {
                return HttpNotFound();
            }
            
            return View(rec);
           //return View();
        }

        // POST: ReclamationAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(Reclamation rec)
        {
            Reclamation rec1 = RS.GetById(rec.ReclamationId);
            rec1.responseRec = rec.responseRec;
            if (ModelState.IsValid)
            {

                RS.Update(rec1);
                RS.Commit();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

            /*  try
              {
                  // TODO: Add update logic here

                  return RedirectToAction("Index");
              }
              catch
              {
                  return View();
              }*/
        }

        // GET: ReclamationAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View(RS.GetById(id));
        }

        // POST: ReclamationAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection,Reclamation r)
        {
            try
            {
                // TODO: Add delete logic here
                r = RS.GetById(id);
                RS.Delete(r);
                RS.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET 
        public ActionResult EmailSetup()
        {

            return View();
        }


        [HttpPost]
        public ActionResult EmailSetup(CRMP.Domain.Entities.gmail model)
        {
            MailMessage mm = new MailMessage("ahmed.chebbah@esprit.tn", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("ahmed.chebbah@esprit.tn", "183JMT1390");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm); 
            ViewBag.Message = "Mail has been send successfully !!";


            return View();
        }






    }
}
