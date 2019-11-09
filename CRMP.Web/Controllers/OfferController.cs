using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRMP.Domain.Entities;
using CRMP.Services.Services;
using CRMP.Services;
using System.Net.Mail;
using Microsoft.AspNet.Identity;
using System.Speech.Synthesis;
using System.Threading.Tasks;

namespace CRMP.Web.Controllers
{
    public class OfferController : Controller
    {

        private OfferService OF;
        private AffectationOffreService AF;
        private UserService US;

        public OfferController()
        {
            this.OF = new OfferService();
            this.AF = new AffectationOffreService();
            this.US = new UserService();
        }


        public ActionResult Home()
        {

            int max = OF.NbrMax();
            Offer offer = OF.Get(p => p.countAff == max);
            return View(offer);
        }

        // GET: Offer
        public ActionResult Index()
        {

           // int max = OF.NbrMax();
            //Offer offer = OF.Get(p => p.countAff == max);
            

              
           //ViewBag.affCount = offer.offerName;
            return View(OF.GetAll());
        }
        public ActionResult offreFront()
        {
            return View(OF.GetAll());
        }
        public ActionResult test()
        {
            return View();
        }

        // GET: Offer/Details/5
        public ActionResult Details(int id)
        {
            var offer = OF.GetById(id);

         

            return View(offer); 
        }

        // GET: Offer/Create
        public ActionResult Create()
        {
            return View();
        }
    



        // POST: Offer/Create
        [HttpPost]
        public ActionResult Create(Offer offer, HttpPostedFileBase file)
        {


          
            offer.ImageOffer = file.FileName;
            OF.Add(offer);
            OF.Commit();
         //   var fileName = "";
            if (file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/UploadedFiles/"), file.FileName);
                file.SaveAs(path);
            }

            // Initialize a new instance of the SpeechSynthesizer.  
            //SpeechSynthesizer synth = new SpeechSynthesizer();

            // Configure the audio output.   
            // synth.SetOutputToDefaultAudioDevice();

            // Speak a string.  


            //  synth.Speak("Your offer has been added");
         /*   var restClient = new RestClient("http://tumblr.com/api/write");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("email", "xxxxx@abc.com");
            request.AddParameter("password", "whatever");
            request.AddParameter("type", "regular");
            request.AddParameter("title", "My post to tumblr");
            request.AddParameter("body", "<b>I am now on tumblr");
            IRestResponse response = restClient.Execute(request);
            */

            return RedirectToAction("Index");




        }

      public ActionResult Activate()
        {
          

            return View(new AffectationOffre());
        }



        [HttpPost]
        public ActionResult Activate(int id, AffectationOffre aff)
        {

            Offer offer = OF.GetById(id);

            
         
            aff.OfferId = offer.OfferId;
            aff.UserProfilId = User.Identity.GetUserId();

            UserProfil user = US.GetById(User.Identity.GetUserId());
           // offer.countAff = 1;
            OF.Update(offer);
            OF.Commit();


           

         
                if (user.solde >= offer.offerprice)
                {
                AF.Add(aff);
                AF.Commit();
                int count = offer.countAff + 1;
                offer.countAff = count;
                OF.Update(offer);
                OF.Commit();
                user.solde = user.solde - (aff.delai * offer.offerprice);
                US.Update(user);
                US.Commit();
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(user.userMail);
                    // mail.To.Add("test@gmail.com");
                    mail.From = new MailAddress("sandra.boughanmi@esprit.tn");
                    mail.Subject = "Offer activiation";

                    mail.Body = "Your "+offer.offerName +"offer has been activated";

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

                }


            }
             else
            {

           try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(user.userMail);
               // mail.To.Add("test@gmail.com");
               mail.From = new MailAddress("sandra.boughanmi@esprit.tn");
                mail.Subject = "insufficient credit";

                mail.Body = "insufficient credit";
              
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

            }
            
            }

         
            return RedirectToAction("Index");



        }


        // GET: Offer/Edit/5
        public ActionResult Edit(int id)
        {
         
          Offer offer = OF.GetById(id);
         
            return View(offer);
        
        }

        // POST: Offer/Edit/5
        [HttpPost]
        public ActionResult Edit(Offer offer, HttpPostedFileBase file)
        {
            {
                try
                {



                    Offer offer1 = OF.GetById(offer.OfferId);
                    offer1.offerName = offer.offerName;
                    offer1.offerDesc = offer.offerDesc;
                    offer1.offerprice =offer.offerprice;
                    offer1.offerType = offer.offerType;
         
                    offer.ImageOffer = file.FileName;
                    offer1.ImageOffer = offer.ImageOffer;
                    OF.Update(offer1);
                    OF.Commit();


                   // var fileName = "";
                    if (file.ContentLength > 0)
                    {
                        var path = Path.Combine(Server.MapPath("~/Content/UploadedFiles/"), file.FileName);
                        file.SaveAs(path);
                    }
           
             
                    return RedirectToAction("Index"); 
                }
                catch
                {
                    return View();
                }
            }

        }

        // GET: Offer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(OF.GetById(id));
        }


        // POST: Offer/Delete/5

        /* public ActionResult Delete(int id, FormCollection collection)
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
         }*/
        [HttpPost]
        public ActionResult Delete(int id, Offer p)
        {
            p = OF.GetById(id);
            OF.Delete(p);
           OF.Commit();
            return RedirectToAction("Index");

        }
    }
}

