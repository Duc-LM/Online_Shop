using Online_Shop.Controllers;
using Online_Shop.Models;
using System.Linq;
using System.Web.Mvc;

namespace Online_Shop.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Order
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        public ActionResult Pending()
        {
            return View(db.Orders.Where(o => o.Status == "Pending").ToList());
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
        public ActionResult ChangeStatus(int? id, FormCollection form)
        {
            if (id == null || db.Orders.Any(o => o.Id == id))
            {
                return RedirectToAction("Index", "Dashboard");
            }
            db.Orders.Find(id).Status = form["status"];
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}