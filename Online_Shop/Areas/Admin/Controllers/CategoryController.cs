using Online_Shop.Controllers;
using Online_Shop.Models;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace Online_Shop.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index(int? page)
        {
            IPagedList<Category> categories = db.Categories.ToList()
                                          .ToPagedList(page ?? 1, 10);
            return View(categories);
        }
        [HttpPost]
        public ActionResult Index(string option, string search, int? page)
        {
            IPagedList<Category> categories = null;
            switch (option)
            {
                case "ID":
                    categories = db.Categories.Where(a => a.Id.ToString() == search).ToList().ToPagedList(page ?? 1, 10);
                    if (categories == null)
                    {
                        ViewBag.Message = "No Result!";
                    }

                    break;
                case "Name":
                    categories = db.Categories.Where(a => a.Name.Contains(search)).ToList().ToPagedList(page ?? 1, 10);
                    if (categories == null)
                    {
                        ViewBag.Message = "No Result!";
                    }

                    break;
                default:
                    categories = db.Categories.ToList().ToPagedList(page ?? 1, 10);

                    break;

            }
            return View(categories);
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
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
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
                db.Entry(db.Categories.Find(category.Id))
                  .CurrentValues
                  .SetValues(category);
                db.SaveChanges();
                return RedirectToAction("Index");
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
            return RedirectToAction("Index");
            //return Json(new { success = true, message = "Deleted" }, JsonRequestBehavior.AllowGet);
        }
    }
}