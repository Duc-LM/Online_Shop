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
                List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
                double total_price = 0;
                foreach (ProductCart item in list)
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
                op.Order.Total_Price = (decimal)((total_price-(total_price * op.Order.Promotion.Percent_discount / 100)) + (double)op.Order.Ship_price);
                db.Orders.Add(op.Order);
                db.SaveChanges();

                int order_id = db.Orders.First(o => o.Customer_name == op.Order.Customer_name && o.Created_date == op.Order.Created_date).Id;
                foreach (ProductCart item in list)
                {
                    var product = db.Products.FirstOrDefault(p => p.Id == item.Id);
                    db.Order_Product.Add(new Order_Product()
                    {
                        Order_id = order_id,
                        Product_id = product.Id,
                        Quantity = item.Quantity,
                        Price = product.Price * item.Quantity,
                        Created_at = DateTime.Now,
                        User_id = ((User)Session["User"]).Id
                    });

                }
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            op.Promotions = db.Promotions.Where(p => DateTime.Compare(DateTime.Now, p.End_date) < 0).ToList();
            return View(op);
        }
    }
}