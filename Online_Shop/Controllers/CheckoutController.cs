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
            if (System.Web.HttpContext.Current.Session["User"] == null)
                return RedirectToAction("Login", "Home");
           if (Session[Convert.ToString(((User)Session["User"]).Id)] == null)
                return RedirectToAction("Index", "Cart");
            if (((List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)]).Count == 0)
                return RedirectToAction("Index", "Cart");
            User user = (User)Session["User"];
            Order order = new Order()
            {
                Customer_name = user.Name,
                Phone_number = user.Phone_number,
                Place_of_receipt = user.Address,
                User_id = ((User)Session["User"]).Id

            };
            List<Promotion> promotions = db.Promotions.Where(p => DateTime.Compare(DateTime.Now, p.End_date) < 0).ToList();
            return View(new OrderPromotions() { Order = order, Promotions = promotions });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderPromotions op)
        {
            if (System.Web.HttpContext.Current.Session["User"] == null)
                return RedirectToAction("Login", "Home");
            if (ModelState.IsValid)
            {
                
                List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
               

                decimal total_price = 0;
                foreach (ProductCart item in list)
                {
                    Product product = db.Products.FirstOrDefault(p => p.Id == item.Id);
                    if (item.Quantity >product.Quantity)
                    {
                        Session["Message"] = "The order quantity of"+product.Name+" exceeds its quantity in stock";
                        return RedirectToAction("Index", "Cart");
                    }
                    total_price += product.Price * item.Quantity;
                }
                foreach (ProductCart item in list)
                {
                    Product product = db.Products.FirstOrDefault(p => p.Id == item.Id);
                    product.Quantity -= item.Quantity;
                }
                if (op.Order.Place_of_receipt.Contains("Ha Noi"))
                {
                    op.Order.Ship_price = 30;
                }
                else
                {
                    op.Order.Ship_price = 80;
                }
                op.Order.Note = "";
                op.Order.Created_date = DateTime.Now;
                op.Order.Status = "Pending";
                op.Order.Total_Price = (decimal)(total_price-(total_price * db.Promotions.FirstOrDefault(o => o.Id==op.Order.Promotion_id).Percent_discount / 100)) + op.Order.Ship_price;
                db.Orders.Add(op.Order);
                db.SaveChanges();
                var order_id = op.Order.Id;
                
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
                Session[Convert.ToString(((User)Session["User"]).Id)] = new List<ProductCart>();
                Session["Message"] = "Your order created successfully";
                return RedirectToAction("Index", "Home");
            }
            op.Promotions = db.Promotions.Where(p => DateTime.Compare(DateTime.Now, p.End_date) < 0).ToList();
            return View(op);
        }
    }
}