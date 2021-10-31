﻿using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Shop.Areas.Admin.Controllers
{
    
    public class DashboardController : BaseController
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            Decimal revenue = 0;
            foreach (var i in db.Orders)
            {
                if(i.Status== "Completed")
                revenue += (decimal) (i.Total_Price - i.Ship_price);
            }
            ViewBag.Revenue = revenue;

            Decimal revenueMonth = 0;
            foreach (var i in db.Orders.Where(o => o.Created_date.Month == DateTime.Now.Month && o.Status=="Completed"))
            {
                revenueMonth += (decimal)(i.Total_Price - i.Ship_price);
            }
            ViewBag.RevenueMonth = revenueMonth;

            ViewBag.PendingOrdersCount = db.Orders.Where(o => o.Status == "Pending").Count();

            var counts= db.Order_Product.GroupBy(p => p.Product_id)
                            .Select(r => new
                            {
                                Product = r.Key,
                                Count = r.Count()
                            }).OrderByDescending(r => r.Count).Take(5);
            List<Product> products = new List<Product>();
            foreach (var i in counts)
            {
                products.Add(db.Products.Find(i.Product));
            }
            ViewBag.CountUsers = db.Users.ToList().Count;
            ViewBag.CountProducts = db.Products.ToList().Count;
            ViewBag.CountOrders = db.Orders.ToList().Count;
            return View(products);
        }
    }
}