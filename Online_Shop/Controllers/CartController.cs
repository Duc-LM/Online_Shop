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
                }
                
            }
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

                list.Where(p => p.Id == id).Select(p => p.Quantity++);
            }

            Session[Convert.ToString(((User)Session["User"]).Id)] = list;


            return RedirectToAction("SingleItem", "ProductView",  id );
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
        public JsonResult UpdateQuantity(int newQuantity, int id)
        {
            List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
            list.Where(p => p.Id == id).Select(p => p.Quantity == newQuantity);
            Session[Convert.ToString(((User)Session["User"]).Id)] = list;
            return Json(new { success = true, message = "Success!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PlusQuantity(int id)
        {
            List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
            foreach (var i in list.Where(p => p.Id == id))
                i.Quantity += 1;
            Session[Convert.ToString(((User)Session["User"]).Id)] = list;
            return Json(new { success = true, message = "Success!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SubtractQuantity(int id)
        {
            List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
            foreach (var i in list.Where(p => p.Id == id))
                i.Quantity -= 1;
            Session[Convert.ToString(((User)Session["User"]).Id)] = list;
            return Json(new { success = true, message = "Success!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteItem(int id)
        {
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