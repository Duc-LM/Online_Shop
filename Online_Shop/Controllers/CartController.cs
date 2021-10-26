using Online_Shop.Models;
using Online_Shop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Online_Shop.Controllers
{
    public class CartController : BaseController
    {


        // GET: Cart
        public ActionResult Index(int? page)
        {
            if ((User)Session["User"] == null)
                return RedirectToAction("Login", "Home");
            List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
            List<ProductCartItem> items = new List<ProductCartItem>();
            decimal total = 0;
            if (list != null)
            {
                foreach (ProductCart i in list)
                {
                    Product product = db.Products.Find(i.Id);
                    items.Add(new ProductCartItem()
                    {
                        Product = product,
                        Quantity = i.Quantity

                    });
                    total += product.Price * i.Quantity;
                }
                
            }
            Session["Total"] = total;
            return View(items);

        }


        public ActionResult AddToCart(int id)
        {

            if ((User)Session["User"] == null)
                return RedirectToAction("Login", "Home");
            User user = (User)Session["User"];
            List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
            if (list == null)
            {
                list = new List<ProductCart>
                {
                    new ProductCart() { Id = id, Quantity = 1 }
                };
            }
            else if (!list.Any(p => p.Id == id))
            {
                list.Add(new ProductCart() { Id = id, Quantity = 1 });
            }
            else
            {

                foreach (var i in list.Where(p => p.Id == id))
                    i.Quantity += 1;
            }
            Session["Total"] = (decimal)Session["Total"] + db.Products.Find(id).Price;
            Session[Convert.ToString(((User)Session["User"]).Id)] = list;
            Session["Message"] = "Added to Cart successfully";
            return RedirectToAction("Index");
            //return RedirectToAction("SingleItem", "ProductView", new { id = id } );
        }
        //[HttpPost]
        //public ActionResult AddToCart(int id, int? quantity)
        //{
        //    if (Session[Convert.ToString(((User)Session["User"]).Id)] != null)
        //    {
        //        Session[Convert.ToString(((User)Session["User"]).Id)] = new List<ProductCart>();
        //    }
        //    else
        //    {
        //        List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
        //        if (list.Find(p => p.Id == id) != null)
        //        {
        //            list.Where(p => p.Id == id).Select(p => p.Quantity += (quantity ?? 1));
        //        }
        //        else
        //        {
        //            list.Add(new ProductCart() { Id = id, Quantity = quantity ?? 1 });
        //        }

        //        Session[Convert.ToString(((User)Session["User"]).Id)] = list;
        //    }
        //}

        [HttpPost]
        public ActionResult UpdateQuantity(int newQuantity, int id)
        {
            if (System.Web.HttpContext.Current.Session["User"] == null)
                return RedirectToAction("Login", "Home");
            List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
            list.Where(p => p.Id == id).Select(p => p.Quantity == newQuantity);
            Session[Convert.ToString(((User)Session["User"]).Id)] = list;
            return Json(new { success = true, message = "Success!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PlusQuantity(int id)
        {
            if (System.Web.HttpContext.Current.Session["User"] == null)
                return RedirectToAction("Login", "Home");
            List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
            foreach (var i in list.Where(p => p.Id == id))
                i.Quantity += 1;
            Session[Convert.ToString(((User)Session["User"]).Id)] = list;
            Session["Total"] = (decimal)Session["Total"] + db.Products.Find(id).Price;
            return Json(new { success = true, message = "Success!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SubstractQuantity(int id)
        {
            if (System.Web.HttpContext.Current.Session["User"] == null)
                return RedirectToAction("Login", "Home");
            List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
            foreach (var i in list.Where(p => p.Id == id && p.Quantity > 1))
                i.Quantity -= 1;
            Session[Convert.ToString(((User)Session["User"]).Id)] = list;
            Session["Total"] = (decimal)Session["Total"] - db.Products.Find(id).Price;
            return Json(new { success = true, message = "Success!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteItem(int id)
        {
            if (System.Web.HttpContext.Current.Session["User"] == null)
                return RedirectToAction("Login", "Home");
            List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
            ProductCart p = list.Where(a => a.Id == id).FirstOrDefault();
            if (p != null)
            {
                list.Remove(p);
                Session[Convert.ToString(((User)Session["User"]).Id)] = list;
                return Json(new { success = true, message = "Deleted" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, message = "Deleted Failed!" }, JsonRequestBehavior.AllowGet);

        }


    }
}