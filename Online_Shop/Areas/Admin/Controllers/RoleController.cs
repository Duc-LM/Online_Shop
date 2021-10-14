using Online_Shop.Controllers;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Shop.Models;

namespace Online_Shop.Areas.Admin.Controllers
{
    public class RoleController : BaseController
    {
        // GET: Admin/Role
        public ActionResult Index(int? page)
        {
            IPagedList<Role> roles = db.Roles.ToList().ToPagedList(page ?? 1, 10);
            return View(roles);
        }
        [HttpPost]
        public ActionResult Index(string option, string search, int? page)
        {
            IPagedList<Role> roles = null;
            switch (option)
            {
                case "ID":
                    roles = db.Roles.Where(a => a.Id.ToString() == search).ToList().ToPagedList(page ?? 1, 10);
                    if (roles == null)
                    {
                        ViewBag.Message = "No Result";
                    }

                    break;
                default:
                    roles = db.Roles.ToList().ToPagedList(page ?? 1, 10);

                    break;
            }
            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                if (db.Roles.FirstOrDefault(c => c.Name == role.Name) != null)
                {
                    ModelState.AddModelError("Name", "This name already existed in the Database");
                    return View();
                }
                db.Roles.Add(role);
                db.SaveChanges();
                TempData["Status"] = "Role Created Successfully";

                return RedirectToAction("Index");
            }
            return View(role);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            Role role = db.Roles.Find(id);
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                Role checkRole = db.Roles.FirstOrDefault(c => c.Name == role.Name);
                if (checkRole == null || checkRole.Id == role.Id)
                {
                    db.Entry(db.Roles.Find(role.Id))
                  .CurrentValues
                  .SetValues(role);
                    db.SaveChanges();
                    TempData["Status"] = "Updated Category Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Name", "This name already existed in the Database");
                    return View(role);
                }
                
            }
            return View(role);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Role role = db.Roles.Find(id);
            db.Roles.Remove(role);
            db.SaveChanges();
            ViewBag.Status = "Role Deleted Successfully";
            return RedirectToAction("Index");
            //return Json(new { success = true, message = "Deleted" }, JsonRequestBehavior.AllowGet);
        }
    }
}