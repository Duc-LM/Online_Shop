
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Shop.Models;

namespace Online_Shop.Areas.Admin.Controllers
{
  [AdminSessionAuthorizeAttribute]
    public class RoleController : BaseController
    {
        // GET: Admin/Role
        public ActionResult Index(int? page)
        {
            var list = (List<Role>)TempData["Roles"];
            if (list!= null && page != null)
            {
                TempData["Roles"] = list;
                return View(list.ToPagedList(page ?? 1, 10));
            }
            if (page == null)
            {
                page = 1;
            }
            var roles = (from r in db.Roles
                         select r).OrderBy(a => a.Id);
           
            return View(roles.ToPagedList(page ?? 1, 10));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int? page)
        {                

            if (!String.IsNullOrEmpty(searchString)) 
            {
                var roles = (from r in db.Roles.Where(a => a.Name.Contains(searchString))
                             select r).OrderBy(a => a.Id).ToList();
                TempData["Roles"] = roles;
                return View(roles.ToPagedList(page ?? 1, 10));
            }
           else
            {
                var roles = (from r in db.Roles
                             select r).OrderBy(a => a.Id).ToList();
                TempData["Roles"] = roles;
                return View(roles.ToPagedList(page ?? 1, 10));
            }          
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
                Session["Message"] = "Role Created Successfully";

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
                    Session["Message"] = "Category Updated Successfully";
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