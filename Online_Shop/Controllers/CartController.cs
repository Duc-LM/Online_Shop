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
            List<Productcart> list = (List<Productcart>)Session["Cart"];
            return View(list);
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
                if (list.Find(p => p.id == pid) != null)
                {
                    list.Where(p => p.id == pid).Select(p => p.quantity++);
                }
                else
                {
                    list.Add(new ProductCart() { id = pid, quantity = 1 });
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
                if (list.Find(p => p.id == pid) != null)
                {
                    list.Where(p => p.id == pid).Select(p => p.quantity += (quantity ?? 1));
                }
                else
                {
                    list.Add(new ProductCart() { id = pid, quantity = quantity ?? 1 });
                }

                Session["Cart"] = list;
            }
        }

        [HttpPost]
        public JsonResult UpdateQuantity(int newQuantity, int id)
        {
            List<Productcart> list = (List<Productcart>)Session["Cart"];
            list.Where(p => p.Id == id).Select(p => p.Quantity == newQuantity);
            Session["Cart"] = list;
            return Json(new { success = true, message = "Success!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PlusQuantity(int id)
        {
            List<Productcart> list = (List<Productcart>)Session["Cart"];
            list.Where(p => p.Id == id).Select(p => p.Quantity += 1);
            Session["Cart"] = list;
            return Json(new { success = true, message = "Success!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SubtractQuantity(int id)
        {
            List<Productcart> list = (List<Productcart>)Session["Cart"];
            list.Where(p => p.Id == id).Select(p => p.Quantity -= 1);
            Session["Cart"] = list;
            return Json(new { success = true, message = "Success!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteItem(int id)
        {
            List<Productcart> list = (List<Productcart>)Session["Cart"];
            Productcart p = list.Where(a => a.Id == id).FirstOrDefault();
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