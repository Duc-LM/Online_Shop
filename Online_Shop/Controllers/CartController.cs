using Online_Shop.Models;
using Online_Shop.Models.DTO;
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
            List<ProductCart> list = (List<ProductCart>)Session["Cart"];
            List<ProductCartItem> items = new List<ProductCartItem>();
            foreach (ProductCart i in list)
            {
                Product product = db.Products.Find(i.Id);
                items.Add(new ProductCartItem()
                {
                    Product = product,
                    Quantity = i.Quantity

                });
            }
            return View(items);
        }


        public void AddToCart(int pid)
        {
            if (Session["cart"] != null)
            {
                Session["cart"] = new List<ProductCart>();
            }
            else
            {
                List<ProductCart> list = (List<ProductCart>)Session["Cart"];
                if (list.Find(p => p.Id == pid) != null)
                {
                    list.Where(p => p.Id == pid).Select(p => p.Quantity++);
                }
                else
                {
                    list.Add(new ProductCart() { Id = pid, Quantity = 1 });
                }

                Session["Cart"] = list;
            }
        }
        [HttpPost]
        public void AddToCart(int pid, int? quantity)
        {
            if (Session["cart"] != null)
            {
                Session["cart"] = new List<ProductCart>();
            }
            else
            {
                List<ProductCart> list = (List<ProductCart>)Session["Cart"];
                if (list.Find(p => p.Id == pid) != null)
                {
                    list.Where(p => p.Id == pid).Select(p => p.Quantity += (quantity ?? 1));
                }
                else
                {
                    list.Add(new ProductCart() { Id = pid, Quantity = quantity ?? 1 });
                }

                Session["Cart"] = list;
            }
        }

        [HttpPost]
        public JsonResult UpdateQuantity(int newQuantity, int id)
        {
            List<ProductCart> list = (List<ProductCart>)Session["Cart"];
            list.Where(p => p.Id == id).Select(p => p.Quantity == newQuantity);
            Session["Cart"] = list;
            return Json(new { success = true, message = "Success!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PlusQuantity(int id)
        {
            List<ProductCart> list = (List<ProductCart>)Session["Cart"];
            list.Where(p => p.Id == id).Select(p => p.Quantity += 1);
            Session["Cart"] = list;
            return Json(new { success = true, message = "Success!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SubtractQuantity(int id)
        {
            List<ProductCart> list = (List<ProductCart>)Session["Cart"];
            list.Where(p => p.Id == id).Select(p => p.Quantity -= 1);
            Session["Cart"] = list;
            return Json(new { success = true, message = "Success!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteItem(int id)
        {
            List<ProductCart> list = (List<ProductCart>)Session["Cart"];
            ProductCart p = list.Where(a => a.Id == id).FirstOrDefault();
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