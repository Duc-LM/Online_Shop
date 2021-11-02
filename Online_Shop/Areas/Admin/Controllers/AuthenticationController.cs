using Online_Shop.Models;
using Online_Shop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Shop.Areas.Admin.Controllers
{
    public class AuthenticationController : Controller
    {
        protected ShopEntities db = new ShopEntities();
        // GET: Admin/Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin userLogin)
        {

            if (ModelState.IsValid)
            {
                User u = db.Users.FirstOrDefault(a => a.User_name == userLogin.user_name);

                if (u != null)
                {
                    var flag = BCrypt.Net.BCrypt.Verify(userLogin.password, u.Password);
                    if (flag == true)
                    {
                        Session["user"] = u;
                        Session["Total"] = (decimal)0;
                        Session["Message"] = "Logged in successfully";
                        return RedirectToAction("Index","Dashboard");
                    }
                    else
                    {
                        ModelState.AddModelError("User_Name", "Incorrect account or password");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("User_Name", "Incorrect account or password");
                    return View();
                }
            }

            return View();
        }

    }
}