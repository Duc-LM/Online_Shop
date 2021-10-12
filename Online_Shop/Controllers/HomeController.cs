using Online_Shop.Models;
using Online_Shop.Models.DTO;
using System.Web.Mvc;

namespace Online_Shop.Controllers
{
    public class HomeController : BaseController
    {


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MailUs()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(UserLogin userLogin)
        {

            if (ModelState.IsValid)
            {
                User u = db.Users.Find(userLogin);
                if (u != null)
                {
                    Session["user_id"] = u.Id;
                    return View();
                }
                else
                {
                    ModelState.AddModelError("Account", "Account does not exist!");
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}