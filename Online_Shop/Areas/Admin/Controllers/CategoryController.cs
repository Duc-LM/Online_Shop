using Online_Shop.Controllers;
using Online_Shop.Models;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Online_Shop.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index(int? page)
        {
            var categories = (from c in db.Categories
                              select c).OrderBy(a => a.Id);
            return View(categories.ToPagedList(page ?? 1, 10));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int? page)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                var categories = (from c in db.Categories.Where(a => a.Name.Contains(searchString) ||                         
                                  a.Short_desc.Contains(searchString))
                                  select c).OrderBy(a => a.Id);
                return View(categories.ToPagedList(page ?? 1, 10));
            }
            else
            {
                var categories = (from c in db.Categories
                                  select c).OrderBy(a => a.Id);
                return View(categories.ToPagedList(page ?? 1, 10));
            }
        }
    
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                //check name -> exist
                if (db.Categories.FirstOrDefault(c => c.Name == category.Name) != null)
                {
                    ModelState.AddModelError("Name", "This name already existed in the Database");
                    return View();
                }
                // add to Db
                db.Categories.Add(category);
                db.SaveChanges();
                TempData["Status"] = "Created Category Successfully";

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            Category category = db.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                //check 
                Category checkCategory = db.Categories.FirstOrDefault(c => c.Name == category.Name);
                if (checkCategory == null || checkCategory.Id == category.Id)
                {
                    db.Entry(db.Categories.Find(category.Id))
                  .CurrentValues
                  .SetValues(category);
                    db.SaveChanges();
                    TempData["Status"] = "Updated Category Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Name", "This name already existed in the Database");
                    return View(category);
                }

            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            TempData["Status"] = "Deleted Category Successfully";
            return RedirectToAction("Index");
            //return Json(new { success = true, message = "Deleted" }, JsonRequestBehavior.AllowGet);
        }
    }
}