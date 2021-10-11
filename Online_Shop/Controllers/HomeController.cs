using Online_Shop.Models;
using Online_Shop.Models.DTO;
using Online_Shop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Shop.Controllers
{
    public class HomeController : BaseController
    {
       

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MailUs() => View();
        public ActionResult Login() => View();

        public ActionResult Login(UserLogin userLogin)
        {
           
            if (ModelState.IsValid)
            {
                User u = db.Users.Find(userLogin);
                if (u != null)
                {
                    Session["user_id"] = u.id;
                    return View();
                }
                else
                    ModelState.AddModelError("Account", "Account does not exist!");
            }
               
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}