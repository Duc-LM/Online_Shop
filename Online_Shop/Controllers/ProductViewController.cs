using Online_Shop.Models;
using Online_Shop.Models.DTO;
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
        //public ActionResult Index(string name)
        //{
        //    List<Product> products = new List<Product>();
        //    products = db.Specs.Where(s => s.Manufacturer == name).Select(s => s.Product).ToList();


        //    return View(products);
        //}

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
        public ActionResult SingleItem(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var product = db.Products.Find(id);
            var spec = db.Specs.FirstOrDefault(s => s.Product_id == id);
            return View(new ProductSpec() { Product = product, Spec = spec });
        }
    }
}