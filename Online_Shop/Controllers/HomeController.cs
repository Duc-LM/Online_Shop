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
                        Session["Total"] =(decimal) 0;
                        Session["Message"] = "Logged in successfully";
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
                Session["Message"] =  "User Created Successfully";
                return RedirectToAction("Index");
            }
            userRoles.Roles = db.Roles.ToList();
            return View();
        }

        public ActionResult UpdatePassword()
        {
            if (System.Web.HttpContext.Current.Session["User"] == null)
                return RedirectToAction("Login", "Home");
            User user = (User)Session["User"];
            var password_User = new Password_User()
            {
                User_Id = user.Id,
                CurrentPassword = user.Password

            };
            return View(password_User);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePassword(Password_User pu)
        {
            if(ModelState.IsValid)
            {
                if (!BCrypt.Net.BCrypt.Verify(pu.CurrentPasswordInput, pu.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "Wrong current password!");
                    return View(pu);
                }else if(pu.CurrentPasswordInput.Equals(pu.NewPassword))
                {
                    ModelState.AddModelError("NewPassword", "The new password must be different from the old password!");
                    return View(pu);
                }
                User user = db.Users.Find(pu.User_Id);
                user.Password = BCrypt.Net.BCrypt.HashPassword(pu.NewPassword);
                user.RePassword = user.Password;
                db.Entry(db.Users.Find(pu.User_Id))
                    .CurrentValues.SetValues(user);
                db.SaveChanges();
                Session["Message"] = "Updated password successfully";
                return RedirectToAction("Index");
            }
            return View(pu);
        }

        public ActionResult Logout()
        {
            Session.Remove("User");
            Session.Remove("Total");
            return RedirectToAction("Index");
        }
    }
}