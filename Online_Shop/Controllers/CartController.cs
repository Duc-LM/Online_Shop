using Online_Shop.Models;
using Online_Shop.Models.DTO;
using Online_Shop.Utils;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Shop.Controllers
{
    public class CartController : BaseController
    {
        
        
        // GET: Cart
        public ActionResult Index(int? page)
        {
            var list = (List<Product>)Session["Cart"];
            var cartDetails = new Dictionary<Product, int>();
            foreach (var item in list)
            {
                cartDetails.Add(db.Products.Where(p => p.id == item.id).FirstOrDefault(), item.quantity);
            }
            // 1page-20record
            var model = cartDetails.ToPagedList(page ?? 1, 20);
            return View(model);
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
        [HttpPost]
        public JsonResult UpdateQuantity(int newQuantity, int id)
        {
            var list = (List<Product>)Session["Cart"];
            list.Where(p => p.id == id).Select(p => p.quantity == newQuantity);
            Session["Cart"] = list;
            return Json(new { success = true, message = "Success!" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteItem(int id)
        {
            var list = (List<Product>)Session["Cart"];
            var p = list.Where(a => a.id == id).FirstOrDefault();
            if (p != null)
            {
                list.Remove(p);
                Session["Cart"] = list;
                return Json(new { success = true, message = "Deleted" }, JsonRequestBehavior.AllowGet);
            }
           
            return Json(new { success = false, message = "Deleted Failed!" }, JsonRequestBehavior.AllowGet);

        }
        


    }
}