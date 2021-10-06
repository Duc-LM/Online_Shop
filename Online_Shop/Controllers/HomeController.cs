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
    public class HomeController : Controller
    {
        static ShopEntities db = new ShopEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login() => View();

        public ActionResult Login(UserLogin userLogin)
        {
            User u = db.Users.Where(a => a.user_name == userLogin.user_name && a.password == MD5Helper.GetHash(userLogin.password)).FirstOrDefault();
            if (u != null)
            {
                Session["user_id"] = u.id;
                return View();
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}