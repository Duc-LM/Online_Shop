using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Shop.Areas.Admin.Controllers
{
    [SessionAuthorize]
    public class DashboardController : BaseController
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            Double revenue = 0;
            foreach (var i in db.Orders)
            {
                revenue += (double) (i.Total_Price - i.Ship_price);
            }
            ViewBag.Revenue = revenue;

            Double revenueMonth = 0;
            foreach (var i in db.Orders.Where(o => o.Created_date.Month == DateTime.Now.Month))
            {
                revenueMonth += (double)(i.Total_Price - i.Ship_price);
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
            return View(products);
        }
    }
}