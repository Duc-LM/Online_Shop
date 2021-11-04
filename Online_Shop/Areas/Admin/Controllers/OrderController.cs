using Online_Shop.Models;
using Online_Shop.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using System;

namespace Online_Shop.Areas.Admin.Controllers
{
  
    public class OrderController : BaseController
    {
        // GET: Admin/Order
        public ActionResult Index(int? page)
        {
            List<Order> orders = new List<Order>();

            orders = db.Orders.OrderByDescending(o => o.Status).ToList();

            return View(orders.ToPagedList(page ?? 1, 10));
        }
        [HttpPost]
        public ActionResult Index(string status, int? page)
        {
            List<Order> orders = new List<Order>();
            if (string.IsNullOrEmpty(status))
            {
                orders = db.Orders.OrderByDescending(o => o.Status).ToList();
            }
            else
            {
                orders = db.Orders.Where(o => o.Status == status).ToList();
            }

            return View(orders.ToPagedList(page ?? 1, 10));
        }
        [HttpPost]
        public ActionResult SearchString(string searchString, int? page)
        {
            List<Order> orders = new List<Order>();
            if(!String.IsNullOrEmpty(searchString))
            {
                orders = db.Orders.Where(o => o.Customer_name.Contains(searchString) ||
                o.Created_date.ToString().Contains(searchString) ||
                o.Phone_number.Contains(searchString) ||
                o.Place_of_receipt.Contains(searchString) ||
                o.Note.Contains(searchString)).ToList();
            } else
            {
                orders = db.Orders.OrderByDescending(o => o.Status).ToList();
            }
            return View("Index", orders.ToPagedList(page ?? 1, 10));
        }
        public ActionResult Edit(int? id)
        {
            if (id == null || !db.Orders.Any(o => o.Id == id))
            {
                return RedirectToAction("Index");
            }

            Order order = db.Orders.Find(id);
            List<Promotion> promotions = db.Promotions.Where(p=>DateTime.Compare(p.End_date,DateTime.Now) > 0).ToList();
            var promotionDescs = new List<PromotionDesc>();
            foreach( var item in promotions)
            {
                promotionDescs.Add(new PromotionDesc { Id = item.Id, Desc = "(Discount: " + item.Percent_discount + "%): " + item.Short_desc });
            }
            // List<Order_Product> products = db.Order_Product.Where(op => op.Order_id == id).ToList();
            OrderProductsPromotions orderProductsPromotions = new OrderProductsPromotions()
            {
                Order = order,
                Order_Products = null, //products,
                Promotions = promotionDescs
            };
            return View(orderProductsPromotions);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderProductsPromotions opp)
        {
            if (ModelState.IsValid)
            {
                Order order = db.Orders.Find(opp.Order.Id);
                opp.Order.Status = "Pending";
                if (opp.Order.Place_of_receipt.Contains("Ha Noi"))
                {
                    opp.Order.Ship_price = 30;
                }
                else
                {
                    opp.Order.Ship_price = 80;
                }
                var order_products = db.Order_Product.Where(o => o.Order_id == opp.Order.Id).ToList();
                decimal total_price = 0;
                foreach (var item in order_products)
                {
                    total_price += item.Price;
                }
                opp.Order.Total_Price = (total_price - (total_price * db.Promotions.FirstOrDefault(o => o.Id == opp.Order.Promotion_id).Percent_discount / 100)) + opp.Order.Ship_price;
                opp.Order.Created_date = order.Created_date;
                if(opp.Order.Note == null)
                {
                    opp.Order.Note = "";
                }
                var orderFind = db.Orders.Find(opp.Order.Id);
                db.Promotions.Find(orderFind.Promotion_id).Quantity_left = db.Promotions.Find(orderFind.Promotion_id).Quantity_left + 1;
                db.Entry(order)
                    .CurrentValues.SetValues(opp.Order);
                db.Promotions.Find(opp.Order.Promotion_id).Quantity_left = db.Promotions.Find(opp.Order.Promotion_id) .Quantity_left- 1;
                db.SaveChanges();
                Session["Message"] = "Order Updated Successfully";
                return RedirectToAction("Index");
            }
            List<Promotion> promotions = db.Promotions.Where(p => DateTime.Compare(p.End_date, DateTime.Now) < 0 && p.Quantity_left > 0).ToList();
            List<Order_Product> products = db.Order_Product.Where(op => op.Order_id == opp.Order.Id ).ToList();
            var promotionDescs = new List<PromotionDesc>();
            foreach (var item in promotions)
            {
                promotionDescs.Add(new PromotionDesc { Id = item.Id, Desc = "(Percent Discount: " + item.Percent_discount + "): " + item.Short_desc });
            }
            opp.Order_Products = products;
            opp.Promotions = promotionDescs;
            return View(opp);
        }


        public ActionResult Detail(int? id)
        {
            if (id == null || !db.Orders.Any(o => o.Id == id))
            {
                return RedirectToAction("Index");
            }

            Order order = db.Orders.Find(id);
            //List<Promotion> promotions = db.Promotions.ToList();
            List<Order_Product> products = db.Order_Product.Where(op => op.Order_id == id).ToList();
            OrderProductsPromotions orderProductsPromotions = new OrderProductsPromotions()
            {
                Order = order,
                Order_Products = products,
                Promotions = null
            };
            return View(orderProductsPromotions);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Order o = db.Orders.Find(id);
            db.Orders.Remove(o);
            db.Order_Product.ToList().RemoveAll(op => op.Order_id == id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ChangeStatus(int? id, string Status)
        {
            if (id == null || !db.Orders.Any(o => o.Id == id))
            {
                return RedirectToAction("Index");
            }
            db.Orders.Find(id).Status = Status;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}