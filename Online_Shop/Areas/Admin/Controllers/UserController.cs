﻿using Online_Shop.Controllers;
using Online_Shop.Models;
using Online_Shop.Models.DTO;
using System;
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
        public ActionResult Create(UserRoles userRoles, HttpPostedFileBase file)
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
                //if (!userRoles.User.Password.Equals(userRoles.User.RePassword))
                //{
                //    ModelState.AddModelError("User_name", "This name must have no space ");
                //    return View();
                //}
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
                db.Users.Add(userRoles.User);
                db.SaveChanges();
                TempData["Status"] = "User Created Successfully";
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
                    ModelState.AddModelError("Dob", "The date of birth is invalid");
                    userRoles.Roles = db.Roles.ToList();
                    return View(userRoles);
                }
                User checkUser = db.Users.FirstOrDefault(u => u.User_name == userRoles.User.User_name);
                if (checkUser == null || checkUser.Id == userRoles.User.Id)
                {
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
                    User u = db.Users.Find(userRoles.User.Id);
                    userRoles.User.Password = u.Password;
                    userRoles.User.RePassword = userRoles.User.Password;
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

        //public ActionResult UpdatePassword(int? id)
        //{

        //    if (!db.Users.Any(u => u.Id == id) || id == null)
        //    {
        //        return RedirectToAction("Index", "Dashboard");
        //    }
        //    User user = db.Users.Find(id);
        //    Password p = new Password()
        //    {
        //        UserId = (int)id,
        //        CurrentPassword = user.Password,
        //        UserName = user.User_name
        //    };
        //    return View(p);
        //}

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
            ViewBag.Validation = ModelState.Values.SelectMany(model => model.Errors);

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
            db.SaveChanges();
            //return Json(new { success = true, message = "Role Updated" }, JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index");
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