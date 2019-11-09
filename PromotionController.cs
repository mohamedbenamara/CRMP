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
    public class PromotionController : Controller
    {
        // GET: Pack

       private PromotionService P;
        private OfferService OF;
        private ProductService PS;
        public PromotionController()
        {
            this.P = new PromotionService();
            this.PS = new ProductService();
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
            ViewBag.ProductId = new SelectList(Products, "ProductId", "prodName");
         

            return View();
        }

        // POST: Pack/Create
        [HttpPost]
        public ActionResult Create(Promotion prdct)
        {
            try
            {


                P.Add(prdct);
                P.Commit();

             Product pp = PS.GetById(prdct.ProductId);

                //  prdct.packPrice = pp.prodPrice;

                float np = pp.prodPrice - ((pp.prodPrice * prdct.promoPrice) / 100);

                pp.newPrice = np;
                PS.Update(pp);
                PS.Commit();
                
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

            Promotion pro = P.GetById(id);
            var Products = PS.GetMany();
            ViewBag.ProductId = new SelectList(Products, "ProductId", "prodName");

            return View(pro);
        }

        // POST: Pack/Edit/5
        [HttpPost]
        public ActionResult Edit(/*int id, FormCollection collection*/Promotion pro)
        {
            try
            {

                Promotion pro1 = P.GetById(pro.PromotionId);
                pro1.promoDesc= pro.promoDesc;
                pro1.promoDateD = pro.promoDateD;
                pro1.promoDateF = pro.promoDateF;
                pro1.ProductId = pro.ProductId;
                pro1.promoPrice = pro.promoPrice;

                P.Update(pro1);
                P.Commit();

                Product pp = PS.GetById(pro1.ProductId);
                float np = pp.prodPrice - ((pp.prodPrice * pro1.promoPrice) / 100);

                pp.newPrice = np;


                PS.Update(pp);
                PS.Commit();


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
            var pro = P.GetById(id); // calling GetEmployeeByID method of EmployeeRepository

            return View(pro);
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
                Product pp = PS.GetById(pa.ProductId);
                pp.newPrice = 0;

                PS.Update(pp);
                PS.Commit(); 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
