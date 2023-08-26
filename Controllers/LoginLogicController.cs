using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.Models;
using System.Web.Security; 

namespace project.Controllers
{
    public class LoginLogicController : Controller
    {
        // GET: LoginLogic
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult login()
        { 
            return View(); 
        }


        [HttpPost]
        public ActionResult login(membership model)
        {

             using(var context = new ClientDBEntities())
                {
                        bool isValid = context.empData.Any(x=>x.userName == model.userName && x.password == model.password);

                        if (isValid)
                        {
                                FormsAuthentication.SetAuthCookie(model.userName, false); 
                                // checkbox to stay signed in

                            return RedirectToAction("Index","portfolio");
                        }

                         ModelState.AddModelError("", "Invalid credentials");

                         return View();
            }


        }


        public ActionResult signUp()
        {
            return View();
        }


        [HttpPost]
        public ActionResult signUp(empData model) 
        {
            using (var context = new ClientDBEntities())
            {
                context.empData.Add(model);
                context.SaveChanges();
            }
                return RedirectToAction("login"); 
        }
       

        public ActionResult logout() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login"); 
        }

        public ActionResult tailwindDemo()
        {
            return View();
        } 

    }
}