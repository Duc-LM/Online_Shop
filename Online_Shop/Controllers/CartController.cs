using Online_Shop.Models;
using Online_Shop.Models.DTO;
using PagedList;
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
            List<Product> list = (List<Product>)Session["Cart"];
            Dictionary<Product, int> cartDetails = new Dictionary<Product, int>();
            foreach (Product item in list)
            {
                cartDetails.Add(db.Products.Where(p => p.Id == item.Id).FirstOrDefault(), item.Quantity);
            }
            // 1page-20record
            IPagedList<KeyValuePair<Product, int>> model = cartDetails.ToPagedList(page ?? 1, 20);
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
        public JsonResult UpdateQuantity(int newQuantity, int id)
        {
            List<Product> list = (List<Product>)Session["Cart"];
            list.Where(p => p.Id == id).Select(p => p.Quantity == newQuantity);
            Session["Cart"] = list;
            return Json(new { success = true, message = "Success!" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteItem(int id)
        {
            List<Product> list = (List<Product>)Session["Cart"];
            Product p = list.Where(a => a.Id == id).FirstOrDefault();
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