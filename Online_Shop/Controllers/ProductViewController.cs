using Online_Shop.Models;
using Online_Shop.Models.DTO;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Online_Shop.Controllers
{
    public class ProductViewController : BaseController
    {
        public ActionResult Index(int? page, string searchString)
        {
            List<Product> list = (List<Product>)TempData["Products"];
            if ( list  != null)
            {
                TempData["Products"] = list;
                return View(list.ToPagedList(page ?? 1, 9));
            }
            List<Product> products = db.Products.ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
               products = db.Products.Where(a => a.Name.Contains(searchString) ||
                                  a.Price.ToString().Contains(searchString) ||
                                  a.Short_desc.Contains(searchString) ||
                                  a.Category.Name.Contains(searchString)
                                  ).ToList();
                TempData["Products"] = products;
                return View(products.ToPagedList(page ?? 1, 9));
            }

            TempData["Products"] = products;
            return View(products.ToPagedList(page ?? 1, 9));

        }

        public ActionResult Category(int? id, int? page)
        {
            var list = (List<Product>)TempData["Categories"];
            if(list != null)
            {
                TempData["Categories"] = list;
                return View(list.ToPagedList(page ?? 1, 9));
            }
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var products = db.Categories.Find(id).Products.ToList();
            TempData["Category_Id"] = id;
            TempData["Categories"] = products;
            return View(products.ToPagedList(page ?? 1, 9));
        }

        [HttpPost]
        public ActionResult Category(int? id, FormCollection form, int? page)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Product> products = db.Categories.Find(id).Products.ToList();


            TempData["Category_Id"] = id;
            switch (form["filter"])
            {
                case "increase":
                    products = db.Categories.Find(id).Products.OrderBy(p => p.Price).ToList();
                    break;
                case "decrease":
                    products = db.Categories.Find(id).Products.OrderByDescending(p => p.Price).ToList();
                    break;

            }
            TempData["Categories"] = products;
            return View(products.ToPagedList(page ?? 1, 9));
        }
        public ActionResult Manufacturer(string name, int? page)
        {
            var list = (List<Product>)TempData["Manufacturers"];
            if( list != null)
            {
                TempData["Manufacturers"] = list;
                return View(list.ToPagedList(page ?? 1, 9));
            }
            List<Product> products = new List<Product>();
            if (string.IsNullOrEmpty(name) || !db.Specs.Any(s => s.Manufacturer == name))
            {
                products = db.Specs.Select(s => s.Product).ToList();
            }
            else
            {
                products = db.Specs.Where(s => s.Manufacturer == name).Select(s => s.Product).ToList();
            }
            TempData["Manufacturer_Name"] = name;
            TempData["Manufacturers"] = products;
            return View(products.ToPagedList(page ?? 1, 9));
        }
        [HttpPost]
        public ActionResult Manufacturer(string name, FormCollection form, int? page)
        {
            List<Product> products = new List<Product>();
            if (string.IsNullOrEmpty(name) || !db.Specs.Any(s => s.Manufacturer == name))
            {
                products = db.Specs.Select(s => s.Product).ToList();
            }
            else
            {
                products = db.Specs.Where(s => s.Manufacturer == name).Select(s => s.Product).ToList();
                switch (form["filter"])
                {
                    case "increase":
                        products = db.Specs.Where(s => s.Manufacturer == name).Select(s => s.Product).ToList().OrderBy(p => p.Price).ToList();
                        break;
                    case "decrease":
                        products = db.Specs.Where(s => s.Manufacturer == name).Select(s => s.Product).ToList().OrderByDescending(p => p.Price).ToList();
                        break;
                }
            }
            TempData["Manufacturer_Name"] = name;
            TempData["Manufacturers"] = products;
            return View(products.ToPagedList(page ?? 1, 9));
        }
        public ActionResult SingleItem(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Product product = db.Products.Find(id);
            Spec spec = db.Specs.FirstOrDefault(s => s.Product_id == id);
            return View(new ProductSpec() { Product = product, Spec = spec });
        }
    }
}