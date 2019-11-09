using CRMP.Domain.Entities;
using CRMP.Services.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Microsoft.AspNet.Identity;
using Rotativa.MVC;



namespace CRMP.Web.Controllers
{
    public class ProductController : Controller
    {
        private ProductService PS;
        private StoreService SS;

        public ProductController()
        {
           // User.Identity.GetUserName();
            PS = new ProductService();
            SS = new StoreService();

        }

        public ActionResult IndexPDF()
        {
            return View(PS.GetAll());
        }
        //@HtmlAction.Link("Nom du button","nom de la fonction dans le controlleur","nom du controlleur");
        public ActionResult Export()
        {
            return new ActionAsPdf("IndexPDF")
            {
                FileName = Server.MapPath("~/Content/PDF/L.pdf")
            };
        }


        public ActionResult IndexFront()
        {
            var list = PS.GetAll().ToList() ;
            // return View(PS.GetMany().ToPagedList(page ?? 1,5));
            return View(list);
        }

        // GET: Product/Details/5
        public ActionResult DetailsFront(int id)
        {
            return View(PS.GetById(id));
        }

        // GET: Product
        public ActionResult Index(int?page)
        {
            var list = PS.GetAll().ToList().ToPagedList(page ?? 1, 3);
           // return View(PS.GetMany().ToPagedList(page ?? 1,5));
            return View(list);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(PS.GetById(id));
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var stores = SS.GetMany();
            
            ViewBag.StoreId = new SelectList(stores, "StoreId", "storeName");
            return View(); 
            //return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            product.prodImage = file.FileName;
            PS.Add(product);
            PS.Commit();
            var fileName = "";
            if (file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/uploads/"), file.FileName);
                file.SaveAs(path);
            }

            // TODO: Add insert logic here

            return RedirectToAction("Index");
        }

        public ActionResult State(int id, Product prod)
        {
            Product p1 = PS.GetById(prod.ProductId);
            //p1.prodState = "Non Disponible";

            return RedirectToAction("Index");

        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = PS.GetById(id);
            return View(p);
        }

        
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product p)
        {
            Product p1 = PS.GetById(p.ProductId);
            p1.store.storeName = p.store.storeName;
            p1.prodDesc = p.prodDesc;
            p1.prodImage = p.prodImage;
            p1.prodName = p.prodName;
            p1.prodPrice = p.prodPrice;
            p1.prodQuantity = p.prodQuantity;
            //p1.prodState = p.prodState;

            if (ModelState.IsValid)
            {
                PS.Update(p1);
                PS.Commit();

                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(PS.GetById(id));
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
                // TODO: Add delete logic here
                product = PS.GetById(id);
                PS.Delete(product);
                PS.Commit();
                return RedirectToAction("Index");
          
        }
        //public ActionResult View (){ return View(); } 

        public ActionResult mailing (String emailbody,Product prod)
        { //var p = prod.prodName;

             MailMessage mailMessage = new MailMessage("rahmaboulila96@gmail.com", "rahma.boulila@esprit.tn");
             // Specify the email body
             mailMessage.Body =  "Je vous recommande le produit x à seulement 20 dinars";
             // Specify the email Subject
             mailMessage.Subject = "Recommandation";


             // Specify the SMTP server name and post number
             SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
             // Specify your gmail address and password
             smtpClient.Credentials = new System.Net.NetworkCredential()
             {
                 UserName = "rahmaboulila96@gmail.com",
                 Password = "rahmaboulila123"
             };
             // Gmail works on SSL, so set this property to true
             smtpClient.EnableSsl = true;
             // Finall send the email message using Send() method
             smtpClient.Send(mailMessage);

            

            return View("View"); 
        }
    }
}
