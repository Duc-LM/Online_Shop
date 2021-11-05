using Online_Shop.Models;
using Online_Shop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace Online_Shop.Controllers
{
    public class CartController : BaseController
    {


        // GET: Cart
        [SessionAuthentication]
        public ActionResult Index(int? page)
        {
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
            return View(items.ToPagedList(page ?? 1, 10));

        }

        [SessionAuthentication]
        public ActionResult AddToCart(int id)
        {
            
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

                foreach (var i in list.Where(p => p.Id == id && p.Quantity < db.Products.Find(p.Id).Quantity))
                   i.Quantity += 1;
                
                   
            }
            decimal total = (decimal)Session["Total"];
            decimal price = db.Products.Find(id).Price;
            Session["Total"] = (decimal)(total + price);
            Session[Convert.ToString(((User)Session["User"]).Id)] = list;
            Session["Message"] = "Added to Cart successfully";
            return RedirectToAction("Index");
           
            //return RedirectToAction("SingleItem", "ProductView", new { id = id } );
        }

        [HttpPost]
        [SessionAuthentication]
        public ActionResult PlusQuantity(int id)
        {
            List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
            int stock = db.Products.Find(id).Quantity;
            foreach (var i in list.Where(p => p.Id == id && p.Quantity < stock))
                i.Quantity += 1;
            Session[Convert.ToString(((User)Session["User"]).Id)] = list;
            Session["Total"] = (decimal)Session["Total"] + db.Products.Find(id).Price;
            return Json(new { success = true, message = "Success!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [SessionAuthentication]
        public ActionResult SubstractQuantity(int id)
        {
            List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
            foreach (var i in list.Where(p => p.Id == id && p.Quantity > 1))
                i.Quantity -= 1;
            Session[Convert.ToString(((User)Session["User"]).Id)] = list;
            Session["Total"] = (decimal)Session["Total"] - db.Products.Find(id).Price;
            return Json(new { success = true, message = "Success!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [SessionAuthentication]
        public ActionResult DeleteItem(int id)
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