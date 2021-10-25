
using Online_Shop.Models;
using Online_Shop.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using System;

namespace Online_Shop.Areas.Admin.Controllers
{
    [SessionAuthorize]
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
            List<Promotion> promotions = db.Promotions.ToList();
            // List<Order_Product> products = db.Order_Product.Where(op => op.Order_id == id).ToList();
            OrderProductsPromotions orderProductsPromotions = new OrderProductsPromotions()
            {
                Order = order,
                Order_Products = null, //products,
                Promotions = promotions
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
                opp.Order.Total_Price = order.Total_Price;
                opp.Order.Ship_price = order.Ship_price;
                opp.Order.Created_date = order.Created_date;
                db.Entry(order)
                    .CurrentValues.SetValues(opp.Order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Promotion> promotions = db.Promotions.ToList();
            List<Order_Product> products = db.Order_Product.Where(op => op.Order_id == opp.Order.Id).ToList();
            opp.Order_Products = products;
            opp.Promotions = promotions;
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
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Order o = db.Orders.Find(id);
            db.Orders.Remove(o);
            db.SaveChanges();
            return null;
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

        public ActionResult Create()
        {
            return View();
        }
    }
}