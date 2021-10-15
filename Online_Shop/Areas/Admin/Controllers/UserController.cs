using Online_Shop.Controllers;
using Online_Shop.Models;
using Online_Shop.Models.DTO;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Shop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {

        // GET: Admin/User
        public ActionResult Index()
        {
            List<User> users = db.Users.ToList();
            List<Role> roles = db.Roles.ToList();
            UsersRoles usersRoles = new UsersRoles() { Users = users, Roles = roles };
            return View(usersRoles);
        }

        public ActionResult Create()
        {
            return View(new UserRoles() { Roles = db.Roles.ToList() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRoles userRole, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(a => a.Name == userRole.User.Name))
                {
                    ModelState.AddModelError("Name", "This name already existed in the Database");
                    return View();
                }
                if (!userRole.User.Password.Equals(userRole.User.RePassword))
                {
                    ModelState.AddModelError("Password", "Two passwords must be the same");
                    return View();
                }
                if (file != null)
                {

                    string InputFileName = Path.GetFileName(file.FileName);
                    string ServerSavePath = Path.Combine(Server.MapPath("~/Include/Images/"), InputFileName);
                    file.SaveAs(ServerSavePath);

                    userRole.User.Avatar = InputFileName;
                }
                else
                {
                    userRole.User.Avatar = "";
                }
                userRole.User.Password = BCrypt.Net.BCrypt.HashPassword(userRole.User.Password);
                db.Users.Add(userRole.User);
                db.SaveChanges();
                TempData["Status"] = "User Created Successfully";
                return RedirectToAction("Index");
            }
            userRole.Roles = db.Roles.ToList();
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            User user = db.Users.Find(id);
            List<Role> roles = db.Roles.ToList();
            UserRoles userRoles = new UserRoles() { User = user, Roles = roles };
            return View(userRoles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserRoles userRoles, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                User checkUser = db.Users.FirstOrDefault(u => u.User_name == userRoles.User.User_name);
                if (checkUser == null || checkUser.Id == userRoles.User.Id)
                {
                    User user = db.Users.Find(userRoles.User.Id);
                    if (file != null)
                    {
                        System.IO.File.Delete(Path.Combine(Server.MapPath("~/Include/Images"), user.Avatar));
                        string InputFileName = Path.GetFileName(file.FileName);
                        string ServerSavePath = Path.Combine(Server.MapPath("~/Include/Images/"), InputFileName);
                        file.SaveAs(ServerSavePath);

                        userRoles.User.Avatar = InputFileName;

                    }
                    else
                    {
                        userRoles.User.Avatar = user.Avatar;
                    }
                    db.Entry(db.Users.Find(userRoles.User.Id))
                        .CurrentValues.SetValues(userRoles.User);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("User_name", "This user name already existed in the Database");
                    userRoles.Roles = db.Roles.ToList();
                    return View(userRoles);
                }
            }
            userRoles.Roles = db.Roles.ToList();
            return View(userRoles);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePassword(int id)
        {
            if (!db.Users.Any(u => u.Id == id))
            {
                return RedirectToAction("Index", "Dashboard");
            }
            Password p = new Password()
            {
                UserId = id,
                CurrentPassword = db.Users.Find(id).Password
            };
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SavePassword(Password p)
        {
            if (ModelState.IsValid)
            {
                if (!BCrypt.Net.BCrypt.Verify(p.CurrentPasswordInput, p.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPasswordInput", "Please enter the correct current password");
                    return View(p);
                }
                if (!p.NewPassword.Equals(p.ReNewPassword))
                {
                    ModelState.AddModelError("NewPassword", "Two passwords must be the same");
                    return View(p);
                }
                db.Users.Find(p.UserId).Password = BCrypt.Net.BCrypt.HashPassword(p.NewPassword);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult ChangeRole(int userId, int newRole_id)
        {
            if (!db.Users.Any(u => u.Id == userId))
            {
                return RedirectToAction("Index", "Dashboard");
            }
            db.Users.Find(userId).Role_id = newRole_id;
            db.SaveChanges();
            return Json(new { success = true, message = "Role Updated" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}