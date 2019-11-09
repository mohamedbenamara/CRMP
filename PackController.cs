using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRMP.Domain.Entities;
using CRMP.Services.Services;
using CRMP.Services;
using System.IO;
using System.Net.Mail;
using System.Configuration;
using System.Net;

namespace CRMP.Web.Controllers
{
    public class PackController : Controller
    {
        // GET: Pack

       private PackService P;
        private OfferService OF;
        private ProductService PS;
        public PackController()
        {
            this.P = new PackService();
            this.PS = new ProductService();
            this.OF = new OfferService();
        }
        public ActionResult Index()
        {
            return View(P.GetMany());
        }

        // GET: Pack/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pack/Create
        public ActionResult Create()
        {

            var Products = PS.GetMany();
            var Offers = OF.GetAll();
            ViewBag.ProductId = new SelectList(Products, "ProductId", "prodName");
          

           ViewBag.OfferId = new SelectList(Offers, "OfferId", "offerName");


            return View(new Pack());
        }

        // POST: Pack/Create
        [HttpPost]
        public ActionResult Create(Pack prdct, HttpPostedFileBase file)
        {
            try
            {
               
              
                P.Add(prdct);
                P.Commit();

               Product pp = PS.GetById(prdct.ProductId);
                Offer of = OF.GetById2(prdct.OfferId);

                prdct.packPrice = pp.prodPrice+of.offerprice;

             
           
               prdct.packImage = "packs-cle-4g-_36_0323285001462529873572c6f514ef12.jpg";
             
              // prdct.packImage = file.FileName;
                P.Update(prdct);
                P.Commit();
                
              //  P.Create(prdct);
                   //  OF.Commit();
                 /*  var fileName = "";
                   if (file.ContentLength > 0)
                   {
                       var path = Path.Combine(Server.MapPath("~/Content/UploadedFiles/"), file.FileName);
                       file.SaveAs(path);
                   }*/

              
                return RedirectToAction("Index");
               
            }
            catch
            {
                return View();
            }
        }

        // GET: Pack/Edit/5
        public ActionResult Edit(int id)
        {
            /*   var pack = P.GetById(id);
               var Products = PS.GetMany();
               ViewBag.ProductId = new SelectList(Products, "ProductId", "prodName");

               return View(pack);*/


            Pack pack = P.GetById(id);
            var Products = PS.GetMany();
            var Offers = OF.GetAll();
        

            ViewBag.OfferId = new SelectList(Offers, "OfferId", "offerName");


            ViewBag.ProductId = new SelectList(Products, "ProductId", "prodName");

            return View(pack);
        }

        // POST: Pack/Edit/5
        [HttpPost]
        public ActionResult Edit(/*int id, FormCollection collection*/Pack pack)
        {
            try
            {

                Pack pack1 = P.GetById(pack.PackId);
                pack1.packName= pack.packName;
                pack1.packDesc = pack.packDesc;
                pack1.packImage = "packs-cle-4g-_36_0323285001462529873572c6f514ef12.jpg";
                pack1.ProductId = pack.ProductId;
                Product pp = PS.GetById(pack.ProductId);
                Offer of = OF.GetById2(pack.OfferId);
                pack1.packPrice = pp.prodPrice+of.offerprice;

                P.Update(pack1);
                P.Commit();


  







             /*   prdct.packImage = "EIYx9qsXkAAEGCm.jpg";
                Product pp = PS.GetById(prdct.ProductId);
                prdct.packPrice = pp.prodPrice;
                P.Update(prdct);
                P.Commit();*/


                /*  try
                  {
                      MailMessage mail = new MailMessage();
                      mail.To.Add("sandraboughanmi94@gmail.com");
                      mail.To.Add("test@gmail.com");
                      mail.From = new MailAddress("sandra.boughanmi@esprit.tn");
                      mail.Subject = "sub";

                      mail.Body = "ujjolkokl";

                      mail.IsBodyHtml = true;
                      SmtpClient smtp = new SmtpClient();
                      smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                      smtp.Credentials = new System.Net.NetworkCredential
                           ("sandra.boughanmi@esprit.tn", "S14763777"); // ***use valid credentials***
                      smtp.Port = 587;

                      //Or your Smtp Email ID and Password
                      smtp.EnableSsl = true;
                      smtp.Send(mail);
                  }
                  catch (Exception ex)
                  {

                  }*/







                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pack/Delete/5
        public ActionResult Delete(int id)
        {
            var pack = P.GetById(id); // calling GetEmployeeByID method of EmployeeRepository

            return View(pack);
        }

        // POST: Pack/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var pa = P.GetById(id);
                P.Delete(pa);
                P.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
