using Online_Shop.Models;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Online_Shop.Areas.Admin.Controllers
{

    public class CategoryController : BaseController
    {

        // GET: Admin/Category
        public ActionResult Index(int? page)
        {
            List<Category> list = (List<Category>)TempData["Categories"];
            if (list != null)
            {
                TempData["Categories"] = list;
                return View(list.ToPagedList(page ?? 1, 10));
            }
            IOrderedQueryable<Category> categories = (from c in db.Categories
                                                      select c).OrderBy(a => a.Id);
            return View(categories.ToPagedList(page ?? 1, 10));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int? page)
        {

            if (!string.IsNullOrEmpty(searchString))
            {
                List<Category> categories = (from c in db.Categories.Where(a => a.Name.Contains(searchString) ||
                                  a.Short_desc.Contains(searchString))
                                             select c).OrderBy(a => a.Id).ToList();
                TempData["Categories"] = categories;
                return View(categories.ToPagedList(page ?? 1, 10));
            }
            else
            {
                List<Category> categories = (from c in db.Categories
                                             select c).OrderBy(a => a.Id).ToList();
                TempData["Categories"] = categories;
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
                Session["Message"] = " Category Created Successfully";

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
                    Session["Message"] = "Category Updated Successfully";
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
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            Session["Message"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
            //return Json(new { success = true, message = "Deleted" }, JsonRequestBehavior.AllowGet);
        }
    }
}