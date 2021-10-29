
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
            Product product = db.Products.FirstOrDefault(p => p.Id == productId);

            return View(new ProductSpec() { Product = product, Spec = spec });
        }

        public ActionResult Create(int? productId)
        {
            Product product = db.Products.FirstOrDefault(p => p.Id == productId);
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
                Session["Message"] = "Specification Added Successfully!";
                return RedirectToAction("Index", "Product");
            }
            ps.Product = db.Products.Find(ps.Spec.Product_id);
            return View(ps);
        }

        public ActionResult Edit(int? productId)
        {
            Product product = db.Products.FirstOrDefault(p => p.Id == productId);
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
                Session["Message"] = "Specification Updated Successfully";
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
            Session["Message"] = "Specification Deleted Successfully";
            return RedirectToAction("Index", "Product");
        }
    }
}