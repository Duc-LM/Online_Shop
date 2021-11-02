﻿
using Online_Shop.Models;
using Online_Shop.Models.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Online_Shop.Areas.Admin.Controllers
{
   [AdminSessionAuthorizeAttribute]
    public class UserController : BaseController
    {

        // GET: Admin/User
        public ActionResult Index(int? page)
        {
            var list = (List<User>)TempData["Users"];
            if(list!= null && page != null)
            {
                TempData["Users"] = list;
                return View(new UsersRoles() { Users = list.ToPagedList(page ?? 1, 10), Roles = db.Roles.ToList()});
            }
            var users = db.Users.ToList().ToPagedList(page ?? 1, 10);
            List<Role> roles = db.Roles.ToList();
            UsersRoles usersRoles = new UsersRoles() { Users = users, Roles = roles };
            
            return View(usersRoles);
        }
        [HttpPost]
        public ActionResult Index(int? page, string searchString)
        {
            IPagedList<User> users = null;
            if (!String.IsNullOrEmpty(searchString))
            {
                 users = db.Users.Where(a => a.Name.Contains(searchString) ||
                a.User_name.Contains(searchString) ||
                a.Email.Contains(searchString) ||
                a.Phone_number.Contains(searchString)).ToList().ToPagedList(page ?? 1, 10);
                TempData["Users"] = db.Users.Where(a => a.Name.Contains(searchString) ||
                a.User_name.Contains(searchString) ||
                a.Email.Contains(searchString) ||
                a.Phone_number.Contains(searchString)).ToList();
            }
            else
            {
                 users = db.Users.ToList().ToPagedList(page ?? 1, 10);
                TempData["Users"] = db.Users.ToList();
            }

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
        public ActionResult Create(UserRoles userRoles, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (userRoles.User.User_name.Contains(' '))
                {
                    ModelState.AddModelError("User.User_name", "This name must have no space ");
                    userRoles.Roles = db.Roles.ToList();
                    return View(userRoles);
                }
                if (db.Users.Any(m => m.User_name == userRoles.User.User_name))
                {
                    ModelState.AddModelError("User.User_name", "This name already existed in the Database ");
                    userRoles.Roles = db.Roles.ToList();
                    return View(userRoles);
                }
                if (db.Users.Any(m => m.Email == userRoles.User.Email))
                {
                    ModelState.AddModelError("User.Email", "This email already existed in the Database ");
                    userRoles.Roles = db.Roles.ToList();
                    return View(userRoles);
                }
                if (db.Users.Any(m => m.Phone_number == userRoles.User.Phone_number))
                {
                    ModelState.AddModelError("User.Phone_number", "This phone number already existed in the Database ");
                    userRoles.Roles = db.Roles.ToList();
                    return View(userRoles);
                }
                if (userRoles.User.Password == null)
                {
                    ModelState.AddModelError("User.Password", "The password is required");
                    userRoles.Roles = db.Roles.ToList();
                    return View(userRoles);
                }
                //if (!userRoles.User.Password.Equals(userRoles.User.RePassword))
                //{
                //    ModelState.AddModelError("User_name", "This name must have no space ");
                //    return View();
                //}
               
                if (DateTime.Compare(userRoles.User.Dob, DateTime.Now) > 0)
                {
                    ModelState.AddModelError("User.Dob", "The date of birth is invalid");
                    userRoles.Roles = db.Roles.ToList();
                    return View(userRoles);
                }
                if (file != null)
                {

                    string InputFileName = (db.Products.ToList().Count + 1).ToString() + Path.GetFileName(file.FileName);
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
                db.Users.Add(userRoles.User);
                db.SaveChanges();
                Session["Message"] = "User Created Successfully";
                return RedirectToAction("Index");
            }
            userRoles.Roles = db.Roles.ToList();
            return View(userRoles);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            User user = db.Users.Find(id);
            user.RePassword = user.Password;
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
                if (DateTime.Compare(userRoles.User.Dob, DateTime.Now) > 0)
                {
                    ModelState.AddModelError("User.Dob", "The date of birth is invalid");
                    userRoles.Roles = db.Roles.ToList();
                    return View(userRoles);
                }
                if (db.Users.Any(m => m.Email == userRoles.User.Email && m.Id != userRoles.User.Id))
                {
                    ModelState.AddModelError("User.Email", "This email already existed in the Database ");
                    userRoles.Roles = db.Roles.ToList();
                    return View(userRoles);
                }
                if (db.Users.Any(m => m.Phone_number == userRoles.User.Phone_number && m.Id != userRoles.User.Id))
                {
                    ModelState.AddModelError("User.Phone_number", "This phone number already existed in the Database ");
                    userRoles.Roles = db.Roles.ToList();
                    return View(userRoles);
                }
                if (db.Users.Any(m => m.User_name == userRoles.User.User_name && m.Id != userRoles.User.Id))
                {
                    ModelState.AddModelError("User.User_name", "This user name already existed in the Database");
                    userRoles.Roles = db.Roles.ToList();
                    return View(userRoles);
                };
                User user = db.Users.Find(userRoles.User.Id);
                    if (file != null)
                    {
                        if (user.Avatar != "")
                        {
                            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Include/Images"), user.Avatar));
                        }


                        string InputFileName = Path.GetFileName(file.FileName);
                        string ServerSavePath = Path.Combine(Server.MapPath("~/Include/Images/"), InputFileName);
                        file.SaveAs(ServerSavePath);

                        userRoles.User.Avatar = InputFileName;

                    }
                    else
                    {
                        userRoles.User.Avatar = user.Avatar;
                    }
                    user.RePassword = user.Password;
                    userRoles.User.Password = user.Password;
                    userRoles.User.RePassword = userRoles.User.Password;
                    db.Entry(user)
                        .CurrentValues.SetValues(userRoles.User);
                    db.SaveChanges();
                    Session["Message"] = "User Update Successfully";
                    return RedirectToAction("Index");
               
            }
            userRoles.Roles = db.Roles.ToList();
            return View(userRoles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult UpdatePassword(int? id, Password p)
        {

            if (id == null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            if (ModelState.IsValid)
            {
                if (!p.NewPassword.Equals(p.ReNewPassword))
                {
                    return PartialView("_Password", p);
                }
                User u = db.Users.Find(id);
                u.Password = BCrypt.Net.BCrypt.HashPassword(p.NewPassword);
                u.RePassword = u.Password;
                db.SaveChanges();
                ViewBag.Message = "Password Updated";
                ModelState.Clear();

                return PartialView("_Password");

            }
            ViewData["Validation-" + id] = ModelState.Values.SelectMany(model => model.Errors);
            ViewBag.userId = id;
            return PartialView("_Password");
        }
        [HttpPost]
        public ActionResult ResetPasswordForm()
        {
            ViewBag.Message = null;
            ViewBag.Validation = null;

            return PartialView("_Password");
        }

        [HttpPost]

        public ActionResult ChangeRole(int id, FormCollection form)
        {

            if (!db.Users.Any(u => u.Id == id))
            {
                return RedirectToAction("Index", "Dashboard");
            }
            db.Users.Find(id).Role_id = Convert.ToInt32(form["Role"]);
            db.Users.Find(id).RePassword = db.Users.Find(id).Password;
            db.SaveChanges();
            //return Json(new { success = true, message = "Role Updated" }, JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ChangePassword()
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
        public ActionResult ChangePassword(Password_User pu)
        {
            if (ModelState.IsValid)
            {
                if (!BCrypt.Net.BCrypt.Verify(pu.CurrentPasswordInput, pu.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPasswordInput", "Wrong current password!");
                    return View(pu);
                }
                else if (pu.CurrentPasswordInput.Equals(pu.NewPassword))
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
                Session["Message"] = "Password Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(pu);
        }


        public ActionResult UpdateProfile()
        {

            User user = (User)Session["User"];
            user.RePassword = user.Password;
            return View((User)Session["User"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProfile(User user, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                if (DateTime.Compare(user.Dob, DateTime.Now) > 0)
                {
                    ModelState.AddModelError("Dob", "The date of birth is invalid");

                    return View(user);
                }
                if (db.Users.Any(m => m.Email == user.Email && m.Id != user.Id))
                {
                    ModelState.AddModelError("Email", "This email already existed in the Database ");

                    return View(user);
                }
                if (db.Users.Any(m => m.Phone_number == user.Phone_number && m.Id != user.Id))
                {
                    ModelState.AddModelError("Phone_number", "This phone number already existed in the Database ");

                    return View(user);
                }
                if (db.Users.Any(m => m.User_name == user.User_name && m.Id != user.Id))
                {
                    ModelState.AddModelError("User_name", "This user name already existed in the Database");

                    return View(user);
                };
                User user1 = db.Users.Find(user.Id);
                user1.RePassword = user.Password;
                if (file != null)
                {
                    if (user.Avatar != "")
                    {
                        System.IO.File.Delete(Path.Combine(Server.MapPath("~/Include/Images"), user.Avatar));
                    }


                    string InputFileName = Path.GetFileName(file.FileName);
                    string ServerSavePath = Path.Combine(Server.MapPath("~/Include/Images/"), InputFileName);
                    file.SaveAs(ServerSavePath);

                    user.Avatar = InputFileName;

                }
                else
                {
                    user.Avatar = user1.Avatar;
                }

                user.Password = user1.Password;
                user.RePassword = user.Password;
                db.Entry(user1)
                    .CurrentValues.SetValues(user);
                db.SaveChanges();
                Session["Message"] = "Updated profile successfully";
                Session["User"] = db.Users.Find(user.Id);
                return RedirectToAction("Index");

            }
            return View(user);
        }

    }



}