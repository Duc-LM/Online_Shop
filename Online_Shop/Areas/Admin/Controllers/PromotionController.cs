using Online_Shop.Controllers;
using Online_Shop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Shop.Areas.Admin.Controllers
{
    public class PromotionController : BaseController
    {
        // GET: Admin/Promotion
        public ActionResult Index(int? page)
        {
            IPagedList<Promotion> promotions = db.Promotions.ToList().ToPagedList(page ?? 1, 10);
            return View(promotions);
        }

        [HttpPost]
        public ActionResult Index(string option, string search, int? page)
        {
            IPagedList<Promotion> promotions = null;
            switch (option)
            {
                case "ID":
                    promotions = db.Promotions.Where(a => a.Id.ToString() == search).ToList().ToPagedList(page ?? 1, 10);
                    if(promotions == null)
                    {
                        ViewBag.Message = "No Result";
                    }
                break;
                case "Name":
                    promotions = db.Promotions.Where(a => a.Name.Contains(search)).ToList().ToPagedList(page ?? 1, 10);
                    if (promotions == null)
                    {
                        ViewBag.Message = "No Result";
                    }
                break;
                default:
                    promotions = db.Promotions.ToList().ToPagedList(page ?? 1, 10);
                    break;
            }
            return View(promotions);
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
                if(db.Promotions.FirstOrDefault(p => p.Name == promotion.Name) != null)
                {
                    ModelState.AddModelError("Name", "This name already existed in the Database");
                    return View();
                }
                if(DateTime.Compare(promotion.Begin_date, promotion.End_date ) > 0)
                {
                    ModelState.AddModelError("Begin_date", "Begin_date must be earlier than End_date");
                    return View();
                }
                db.Promotions.Add(promotion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int ? id)
        {
            if(id == null)
            {
                return HttpNotFound();
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
                    return View();
                }
                Promotion checkPromotion = db.Promotions.FirstOrDefault(p => p.Name == promotion.Name);
                if(checkPromotion == null || checkPromotion.Id == promotion.Id)
                {
                    db.Entry(db.Promotions.Find(promotion.Id))
                    .CurrentValues
                    .SetValues(promotion);
                    db.SaveChanges();
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
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int ? id)
        {
            Promotion promotion = db.Promotions.Find(id);
            db.Promotions.Remove(promotion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}