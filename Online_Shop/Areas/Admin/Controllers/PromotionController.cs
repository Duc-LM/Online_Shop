
using Online_Shop.Models;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Online_Shop.Areas.Admin.Controllers
{
    [SessionAuthorize]
    public class PromotionController : BaseController
    {
        // GET: Admin/Promotion
        public ActionResult Index(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var promotions = (from p in db.Promotions
                         select p).OrderBy(a => a.Id);
           
            return View(promotions.ToPagedList(page ?? 1, 10));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int? page)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                var promotions = (from p in db.Promotions.Where(a => a.Name.Contains(searchString) || 
                                  a.Percent_discount.ToString().Contains(searchString) ||
                                  a.Short_desc.Contains(searchString))
                             select p).OrderBy(a => a.Id);
                return View(promotions.ToPagedList(page ?? 1, 10));
            }
            else
            {
                var promotions = (from p in db.Promotions
                             select p).OrderBy(a => a.Id);
                return View(promotions.ToPagedList(page ?? 1, 10));
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                if (db.Promotions.FirstOrDefault(p => p.Name == promotion.Name) != null)
                {
                    ModelState.AddModelError("Name", "This name already existed in the Database");
                    return View();
                }
                if (DateTime.Compare(promotion.Begin_date, DateTime.Now) < 0)
                {
                    ModelState.AddModelError("Begin_date", "Begin date must not be earlier than now");
                    return View();
                }
                if (DateTime.Compare(promotion.End_date, DateTime.Now) < 0)
                {
                    ModelState.AddModelError("End_date", "End date must not be earlier than now");
                    return View();
                }
                if (DateTime.Compare(promotion.Begin_date, promotion.End_date) > 0)
                {
                    ModelState.AddModelError("Begin_date", "Begin_date must be earlier than End_date");
                    return View();
                }

                db.Promotions.Add(promotion);
                db.SaveChanges();
                Session["Message"] = "Promotion Created Successfully";
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
            Promotion promotion = db.Promotions.Find(id);
            return View(promotion);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Promotion promotion)
        {
            if (ModelState.IsValid)
            {

                if (DateTime.Compare(promotion.Begin_date, promotion.End_date) > 0)
                {
                    ModelState.AddModelError("Begin_date", "Begin_date must be earlier than End_date");
                    return View(promotion);
                }
                if (DateTime.Compare(promotion.Begin_date, DateTime.Now) < 0)
                {
                    ModelState.AddModelError("Begin_date", "Begin date must not be earlier than now");
                    return View(promotion);
                }
                if (DateTime.Compare(promotion.End_date, DateTime.Now) < 0)
                {
                    ModelState.AddModelError("End_date", "End date must not be earlier than now");
                    return View(promotion);
                }
                Promotion checkPromotion = db.Promotions.FirstOrDefault(p => p.Name == promotion.Name);
                if (checkPromotion == null || checkPromotion.Id == promotion.Id)
                {
                    db.Entry(db.Promotions.Find(promotion.Id))
                    .CurrentValues
                    .SetValues(promotion);
                    db.SaveChanges();
                    Session["Message"] = "Promotion Updated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Name", "This name already existed in the Database");
                    return View(promotion);
                }
            }

            return View(promotion);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Promotion promotion = db.Promotions.Find(id);
            db.Promotions.Remove(promotion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}