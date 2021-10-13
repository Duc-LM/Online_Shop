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
                return RedirectToAction("Index", "Admin");
            }
            Spec spec = db.Specs.FirstOrDefault(s => s.Product_id == productId);
            Product product = db.Products.FirstOrDefault(p => p.Id == productId);

            return View(new ProductSpec() { Product = product, Spec = spec });
        }

        public ActionResult Create(int? productId)
        {
            if (productId == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            Spec spec = new Spec() { Product_id = (int)productId };
            Product product = db.Products.FirstOrDefault(p => p.Id == productId);
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
            if (productId == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            Spec spec = db.Specs.FirstOrDefault(s => s.Product_id == productId);
            Product product = db.Products.FirstOrDefault(p => p.Id == productId);
            return View(new ProductSpec() { Product = product, Spec = spec });
        }
    }
}