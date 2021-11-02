using Online_Shop.Models;
using Online_Shop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace Online_Shop.Controllers
{
    [SessionAuthentication]
    public class CheckoutController : BaseController
    {
        
        public ActionResult Index(int? page)
        {
            var orders = db.Users.Find(((User)Session["User"]).Id).Orders.OrderByDescending(o => o.Status).ToList();
            var list = (List<Order>)TempData["Orders"];
            if (list != null)
            {
                TempData["Orders"] = list;
                return View(list.ToPagedList(page ?? 1, 10));
            }

            TempData["Orders"] = orders;
            return View(orders.ToPagedList(page ?? 1, 10));

        }
        [HttpPost]
        public ActionResult Index (int? page, string searchString)
        {
            var orders = db.Users.Find(((User)Session["User"]).Id).Orders.OrderByDescending(o => o.Status).ToList();
            var list = new List<Order>();
            if (!String.IsNullOrEmpty(searchString))
            {
                list = orders.Where(o => o.Customer_name.Contains(searchString) ||
                o.Created_date.ToString().Contains(searchString) ||
                o.Phone_number.Contains(searchString) ||
                o.Place_of_receipt.Contains(searchString) ||
                o.Note.Contains(searchString)).OrderByDescending(o => o.Status).ToList();
            }
            else
            {
                list = orders.OrderByDescending(o => o.Status).ToList();
            }
            TempData["Orders"] = list;
            return View(list.ToPagedList(page ?? 1, 10));
        }
      

        // GET: Checkout
        public ActionResult Create()
        {
           if (Session[Convert.ToString(((User)Session["User"]).Id)] == null)
                return RedirectToAction("Index", "Cart");
            if (((List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)]).Count == 0)
                return RedirectToAction("Index", "Cart");
            else
            {
                List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
                foreach (ProductCart item in list)
                {
                    Product product = db.Products.FirstOrDefault(p => p.Id == item.Id);
                    if (item.Quantity > product.Quantity)
                    {
                        Session["Message"] = "The order quantity of" + product.Name + " exceeds its quantity in stock";
                        return RedirectToAction("Index", "Cart");
                    } 
                }
            }

            User user = (User)Session["User"];
            List<ProductCart> cart = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
            List<ProductCartItem> items = new List<ProductCartItem>();
            decimal total = 0;
            if (cart != null)
            {
                foreach (ProductCart i in cart)
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
            if (((User)Session["User"]).Address.ToLower().Contains("ha noi") || ((User)Session["User"]).Address.ToLower().Contains("hà nội"))
                ViewBag.Ship_Price = (decimal) 10;
            else
                ViewBag.Ship_Price = (decimal)20;
            Order order = new Order()
            {
                Customer_name = user.Name,
                Phone_number = user.Phone_number,
                Place_of_receipt = user.Address,
                User_id = ((User)Session["User"]).Id

            };
            List<Promotion> promotions = db.Promotions.Where(p => DateTime.Compare(DateTime.Now, p.End_date) < 0 && p.Quantity_left > 0 && DateTime.Compare(p.Begin_date, DateTime.Now) <= 0).ToList();
            var promotionDescs = new List<PromotionDesc>();
            foreach (var item in promotions)
            {
                promotionDescs.Add(new PromotionDesc { Id = item.Id, Desc = "(Discount: " + item.Percent_discount + "%): " + item.Short_desc });
            }
            return View(new OrderPromotions() { Order = order, Promotions = promotionDescs });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderPromotions op)
        {
            if (ModelState.IsValid)
            {
                
                List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
                if (((User)Session["User"]).Address.ToLower().Contains("ha noi") || ((User)Session["User"]).Address.ToLower().Contains("hà nội"))
                    op.Order.Ship_price = (decimal)10;
                else
                        op.Order.Ship_price = (decimal)20;
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
                if(op.Order.Note ==null)
                    op.Order.Note = "";
                op.Order.Created_date = DateTime.Now;
                op.Order.Status = "Pending";
                op.Order.Total_Price = (decimal)(total_price*(100 - db.Promotions.FirstOrDefault(o => o.Id==op.Order.Promotion_id).Percent_discount) / 100) 
                                        + op.Order.Ship_price;
                db.Orders.Add(op.Order);
                db.Promotions.FirstOrDefault(o => o.Id == op.Order.Promotion_id).Quantity_left = db.Promotions.FirstOrDefault(o => o.Id == op.Order.Promotion_id).Quantity_left - 1;
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
                Session["Message"] = "Your order created successfully. QTD shop's staff will contact you after 5 minutes.";
                return RedirectToAction("Index", "Home");
            }
            
            var promotions = db.Promotions.Where(p => DateTime.Compare(DateTime.Now, p.End_date) < 0).ToList();
            var promotionDescs = new List<PromotionDesc>();
            foreach (var item in promotions)
            {
                promotionDescs.Add(new PromotionDesc { Id = item.Id, Desc = "(Discount: " + item.Percent_discount + "%): " + item.Short_desc });
            }
            op.Promotions = promotionDescs;
            return View(op);
        }

        public ActionResult Detail(int? id )
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Order order = db.Orders.Find(id);
            List<Order_Product> products = db.Order_Product.Where(op => op.Order_id == id).ToList();
            OrderProductsPromotions orderProductsPromotions = new OrderProductsPromotions()
            {
                Order = order,
                Order_Products = products,
                Promotions = null
            };
            return View(orderProductsPromotions);
        }
       
    }
}