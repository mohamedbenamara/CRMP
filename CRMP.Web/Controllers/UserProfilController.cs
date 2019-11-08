using CRMP.Domain.Entities;
using CRMP.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using CRMP.Web.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CRMP.Web.Models;
using static CRMP.Web.Controllers.ManageController;
using System.IO;

namespace CRMP.Web.Controllers
{
    public class UserProfilController : Controller


    {
        private UserProfilService US;
        
        public UserProfilController()
        {
            US = new UserProfilService();
        }
        // GET: UserProfil
        public ActionResult Index()
        {
            
            return View(US.GetAll());
        }

        // GET: UserProfil
        public ActionResult IndexBack()
        {

            return View(US.GetAll());
        }







        [HttpPost]
        public ActionResult Index(string filtre)
        {
            var list = US.GetMany();
            


            // recherche
            if (!String.IsNullOrEmpty(filtre))
            {
                list = list.Where(m => m.UserProfilId.ToString().Equals(filtre)).ToList();
                
            }

            return View(list);



        }

        [HttpPost]
        public ActionResult transfertPt(UserProfil User1,UserProfil User2,string num,int pt)
        {
            
            User1 = US.GetByIdString(User.Identity.GetUserId());
            User1.point = User1.point - pt;

            var list = US.GetMany();
          //  list = list.Where(m => m.userNum==num)



            
            US.Update(User1);


            // recherche
            if (!String.IsNullOrEmpty(num))
            {
                list = list.Where(m => m.UserProfilId.ToString().Equals(num)).ToList();
            }

            return View(list);



        }



        // GET: UserProfil
        public ActionResult MyProfil()
        {
            

            return View(US.GetAll());
        }

        // GET: UserProfil/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: UserProfil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProfil/Create
        [HttpPost]
        public ActionResult Create(UserProfil UserP, HttpPostedFile file)
        {
            
               // UserP = new UserProfil();

                UserP.image = file.FileName;


                //var fileName = "";
                if (file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/Uploads/"), file.FileName);
                    file.SaveAs(path);


                }
                //   UserP.image = file.FileName;

                // UserP.role=User.Identity.GetUserId

                UserP.UserProfilId = User.Identity.GetUserId();

                // UserP.Name = User.Identity.GetUserName();
                // TODO: Add insert logic here
                US.Add(UserP);

                US.Commit();



                return RedirectToAction("Index");
            
            
        }



        // GET: UserProfil/Create
        public ActionResult Create2()
        {
            return View();
        }

        // POST: UserProfil/Create2
        [HttpPost]
        public ActionResult Create2(UserProfil UserP, HttpPostedFile file)
        {
            try
            {
                  UserP.image= file.FileName;
                
                   var fileName = "";
                   if (file.ContentLength > 0)
                   {
                       var path = Path.Combine(Server.MapPath("~/Content/Uploads"), file.FileName);
                       file.SaveAs(path);


                   }
                UserP.image = file.FileName;


                US.Add(UserP);

                US.Commit();



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        // GET: UserProfil/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserProfil/Edit/5
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

        // GET: UserProfil/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserProfil/Delete/5
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
