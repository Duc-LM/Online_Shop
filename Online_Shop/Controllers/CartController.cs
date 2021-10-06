using Online_Shop.Models;
using Online_Shop.Models.DTO;
using Online_Shop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Shop.Controllers
{
    public class CartController : Controller
    {

        ShopEntities db = new ShopEntities();
        
        // GET: Cart
        public ActionResult Index()
        {
            var list = (List<Product>)Session["Cart"];
            var cartDetails = new Dictionary<Product, int>();
            foreach (var item in list)
            {
                cartDetails.Add(db.Products.Where(p => p.id == item.id).FirstOrDefault(), item.quantity);
            }
            return View(cartDetails);
        }

        public void AddToCart(int pid)
        {
            if (Session["cart"] != null)
            {
                Session["cart"] = new List<ProductCart>();
            }
            else
            {
                var list = (List<ProductCart>)Session["Cart"];
                if (list.Find(p => p.id == pid) != null)
                    list.Where(p => p.id == pid).Select(p => p.quantity++);
                else
                    list.Add(new ProductCart() { id = pid ,quantity = 1  });
                Session["Cart"] = list;
            }
        }

        


    }
}