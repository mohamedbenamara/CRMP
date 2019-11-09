using CRMP.Domain.Entities;
using CRMP.Services.Services;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using Rotativa;
using Rotativa.MVC;
using PagedList;
using PagedList.Mvc;
using Microsoft.AspNet.Identity;

namespace Web.Controllers
{
    public class CommandeController : Controller
    {
        private CommandeService cs;
        private ProductService ps;

        public CommandeController()
        {
            this.cs = new CommandeService();
            this.ps = new ProductService();

        }
        // GET: Commande
        public ActionResult Index(int? page)
        {
            var list = cs.GetAll().ToList().ToPagedList(page ?? 1, 3);
            return View(list);
        }

        // GET: Commande/Details/5
        public ActionResult Details(int id)
        {
            return View(cs.GetById(id));
        }

        // GET: Commande/Create
        public ActionResult Create()
        {
            var products = ps.GetMany();
            ViewBag.ProductId = new SelectList(products, "ProductId", " prodName");
            //ViewBag.ProductId = new SelectList(cs.unitofwork.DataContext.Products, "ProductId", "Name");
            return View();
        }

        // POST: Commande/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Commande cmd, string emailbody)
        {

            try
            {
                MailMessage mailMessage = new MailMessage("haifafeddaoui96@gmail.com", User.Identity.Name);
                // Specify the email body
                mailMessage.Body = "Cher(e) Haifa,Merci d’avoir effectué vos achats !Votre commande 303942122 est en attente de confirmation.";
                // Specify the email Subject
                mailMessage.Subject = "Email de Confirmation";


                // Specify the SMTP server name and post number
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                // Specify your gmail address and password
                smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = "haifafeddaoui96@gmail.com",
                    Password = "haifa27356205"
                };
                // Gmail works on SSL, so set this property to true
                smtpClient.EnableSsl = true;
                // Finall send the email message using Send() method
                smtpClient.Send(mailMessage);
                //cmd.UserId = 7;
                cmd.UserId = User.Identity.GetUserId();

                cs.Add(cmd);
                cs.Commit();
                Product pp = ps.GetById(cmd.ProductId);

                cmd.total = pp.prodPrice * cmd.q;
                cs.Update(cmd);
                cs.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Commande/Edit/5
        public ActionResult Edit(int id)
        {


            Commande c = cs.GetById(id);
            // ViewBag.ProductId = new SelectList
            //(cs.unitofwork.DataContext.Products, "ProductId", "Name", commande.ProductId);
            var products = ps.GetMany();
            ViewBag.ProductId = new SelectList(products, "ProductId", " prodName");
            return View(c);
        }


        // POST: Commande/Edit/5
        [HttpPost]
        public ActionResult Edit(Commande c)
        {
            Commande c1 = cs.GetById(c.CommandeId);
            //c.UserId = 7;
            c1.q = c.q;
            c1.ProductId = c.ProductId;
            if (ModelState.IsValid)
            {
                cs.Update(c1);
                cs.Commit();
                Product pp = ps.GetById(c1.ProductId);
                c1.total = pp.prodPrice * c1.q;
                cs.Update(c1);
                cs.Commit();
            }
            /*try
            {
                // TODO: Add update logic here
                cs.Update(cms);
                Product pp = ps.GetById(cms.ProductId);

                cms.total = pp.prodPrice * cms.q;
                cs.Update(cms);
                
            }
            catch
            {
                return View();
            }*/
            return RedirectToAction("Index");
        }

        // GET: Commande/Delete/5
        public ActionResult Delete(int id)
        {
            return View(cs.GetById(id));
        }

        // POST: Commande/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Commande c)
        {
            c = cs.GetById(id);
            //c.UserId = 7;
            cs.Delete(c);
            cs.Commit();
            return RedirectToAction("Index");
        }
        ///////back ///////////
        public ActionResult Index2()
        {
            ViewBag.cmdd = cs.nbr();
            var list = cs.GetAll().ToList();
            return View(list);


        }
        public ActionResult liste()
        {
            var list = cs.GetAll().ToList();
            return View(list);
        }

        public ActionResult Pdf()
        {
            var q = new ActionAsPdf("liste");
            return (q);

        }
        public ActionResult Confirmer(int id)
        {
            Commande c = cs.GetById(id);
            c.etat = "confirme";
            //c.UserId = 7;
            MailMessage mailMessage = new MailMessage("haifafeddaoui96@gmail.com", User.Identity.Name);
            // Specify the email body
            mailMessage.Body = "Cher(e) Haifa,Votre commande 303942122 a été confirmée avec succès";
            // Specify the email Subject
            mailMessage.Subject = "Email de Confirmation";


            // Specify the SMTP server name and post number
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            // Specify your gmail address and password
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "haifafeddaoui96@gmail.com",
                Password = "haifa27356205"
            };
            // Gmail works on SSL, so set this property to true
            smtpClient.EnableSsl = true;
            // Finall send the email message using Send() method
            smtpClient.Send(mailMessage);
            cs.Update(c);
            cs.Commit();
            return RedirectToAction("Index2");


        }


    }

}
