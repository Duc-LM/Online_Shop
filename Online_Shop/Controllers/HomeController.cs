
using Online_Shop.Models;
using Online_Shop.Models.DTO;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System;
using System.IO;

namespace Online_Shop.Controllers
{
    public class HomeController : BaseController
    {


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MailUs()
        {
            return View();
        }

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
                
               if (u!=null)
                {
                    var flag = BCrypt.Net.BCrypt.Verify(userLogin.password, u.Password);
                    if (flag == true)
                    {
                        Session["user"] = u;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("User_Name", "Account does not exist!");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("User_Name", "Account does not exist!");
                    return View();
                }
            }

            return View();
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRoles userRoles, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (userRoles.User.User_name.Contains(' '))
                {
                    ModelState.AddModelError("User_name", "This name must have no space ");
                    return View();
                }
                if (db.Users.Any(m => m.User_name == userRoles.User.User_name))
                {
                    ModelState.AddModelError("User_name", "This name already existed in the Database ");
                    return View();
                }
                if (userRoles.User.Password == null)
                {
                    ModelState.AddModelError("Password", "The password is required");
                    return View();
                }
               
                if (db.Users.Any(a => a.Name == userRoles.User.Name))
                {
                    ModelState.AddModelError("Name", "This name already existed in the Database");
                    return View();
                }
                if (DateTime.Compare(userRoles.User.Dob, DateTime.Now) > 0)
                {
                    ModelState.AddModelError("Dob", "The date of birth is invalid");
                    return View();
                }
                if (file != null)
                {

                    string InputFileName = userRoles.User.Id + Path.GetFileName(file.FileName);
                    string ServerSavePath = Path.Combine(Server.MapPath("~/Include/Images/"), InputFileName);
                    file.SaveAs(ServerSavePath);

                    userRoles.User.Avatar = InputFileName;
                }
                else
                {
                    userRoles.User.Avatar = "";
                }
                userRoles.User.Password = BCrypt.Net.BCrypt.HashPassword(userRoles.User.Password);
                userRoles.User.RePassword = userRoles.User.Password;
                userRoles.User.Role_id = db.Roles.FirstOrDefault(r => r.Name.ToUpper().Equals("USER")).Id;
                db.Users.Add(userRoles.User);                
                db.SaveChanges();
                TempData["Status"] = "User Created Successfully";
                return RedirectToAction("Index");
            }
            userRoles.Roles = db.Roles.ToList();
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