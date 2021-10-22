using Online_Shop.Controllers;
using Online_Shop.Models;
using Online_Shop.Models.DTO;
using System.Linq;
using System.Web.Mvc;

namespace Online_Shop.Areas.Admin.Controllers
{
    public class SpecController : BaseController
    {
        // GET: Admin/Spec
        public ActionResult Details(int? productId)
        {
            if (productId == null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            Spec spec = db.Specs.FirstOrDefault(s => s.Product_id == productId);
            Productcart product = db.Products.FirstOrDefault(p => p.Id == productId);

            return View(new ProductSpec() { Product = product, Spec = spec });
        }

        public ActionResult Create(int? productId)
        {
            Productcart product = db.Products.FirstOrDefault(p => p.Id == productId);
            if (productId == null || product == null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            Spec spec = new Spec() { Product_id = (int)productId };
            return View(new ProductSpec() { Product = product, Spec = spec });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductSpec ps)
        {
            if (ModelState.IsValid)
            {
                db.Specs.Add(ps.Spec);
                db.SaveChanges();
                ViewBag.Status = "Added Specification Successfully!";
                return RedirectToAction("Index", "Product");
            }
            ps.Product = db.Products.Find(ps.Spec.Product_id);
            return View(ps);
        }

        public ActionResult Edit(int? productId)
        {
            Productcart product = db.Products.FirstOrDefault(p => p.Id == productId);
            if (productId == null || product == null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            Spec spec = db.Specs.FirstOrDefault(s => s.Product_id == productId);
            return View(new ProductSpec() { Product = product, Spec = spec });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductSpec ps)
        {
            if (ModelState.IsValid)
            {
                db.Entry(db.Specs.FirstOrDefault(s => s.Product_id == ps.Spec.Product_id))
                    .CurrentValues.SetValues(ps.Spec);
                db.SaveChanges();
                TempData["Status"] = "Updated Spec Successfully";
                return RedirectToAction("Index", "Product");
            }
            ps.Product = db.Products.Find(ps.Spec.Product_id);
            return View(ps);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int productId)
        {
            Spec spec = db.Specs.FirstOrDefault(s => s.Product_id == productId);
            db.Specs.Remove(spec);
            db.SaveChanges();
            TempData["Status"] = "Deleted Spec Successfully";
            return RedirectToAction("Index", "Product");
        }
    }
}