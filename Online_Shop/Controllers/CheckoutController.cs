using Online_Shop.Models;
using Online_Shop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Online_Shop.Controllers
{
    public class CheckoutController : BaseController
    {
        // GET: Checkout
        public ActionResult Create()
        {
            User user = (User)Session["User"];
            Order order = new Order()
            {
                Customer_name = user.Name,
                Phone_number = user.Phone_number,
                Place_of_receipt = user.Address,

            };
            List<Promotion> promotions = db.Promotions.Where(p => DateTime.Compare(DateTime.Now, p.End_date) < 0).ToList();
            return View(new OrderPromotions() { Order = order, Promotions = promotions });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderPromotions op)
        {
            if (ModelState.IsValid)
            {
                List<Productcart> list = (List<Productcart>)Session["Cart"];
                double total_price = 0;
                foreach (Productcart item in list)
                {
                    total_price += (double)db.Products.FirstOrDefault(p => p.Id == item.Id).Price * item.Quantity;
                }

                if (op.Order.Place_of_receipt.Contains("Ha Noi"))
                {
                    op.Order.Ship_price = 30;
                }
                else
                {
                    op.Order.Ship_price = 80;
                }

                op.Order.Created_date = DateTime.Now;
                op.Order.Status = "Pending";
                op.Order.Total_Price = (decimal)((total_price * op.Order.Promotion.Percent_discount / 100) + (double)op.Order.Ship_price);
                db.Orders.Add(op.Order);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            op.Promotions = db.Promotions.Where(p => DateTime.Compare(DateTime.Now, p.End_date) < 0).ToList();
            return View(op);
        }
    }
}