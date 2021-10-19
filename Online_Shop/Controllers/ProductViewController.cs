using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Shop.Controllers
{
    public class ProductViewController : BaseController
    {
        // GET: ProductView
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(int ? id)
        {
            if(id== null)
            {
                return RedirectToAction("Index", "Home");
            }
            var products = db.Categories.Find(id).Products; 

            return View(products);
        }
        public ActionResult Manufacturer(string name)
        {
            List<Product> products = new List<Product>();
            if(name == null || !db.Specs.Any(s => s.Manufacturer == name))
            {
                products = db.Specs.Select(s => s.Product).ToList();
            }
            else
            {
                products = db.Specs.Where(s => s.Manufacturer == name).Select(s => s.Product).ToList();
            }
            
            return View(products);
        }
        public ActionResult SingleItem(string image)
        {
            
            return View();
        }
    }
}