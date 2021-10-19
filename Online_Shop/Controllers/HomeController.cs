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
        //public ActionResult Login()
        //{
        //    return View("login");
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(UserLogin userLogin)
        //{
        //    var a = BCrypt.Net.BCrypt.Verify(userLogin.password, "asdfasfd");
        //    if (ModelState.IsValid)
        //    {
        //        User u = db.Users.Where(a=> a.User_name == userLogin.user_name && BCrypt.Net.BCrypt.EnhancedVerify(userLogin.password,a.Password)).FirstOrDefault();
        //        if (u != null)
        //        {
        //            Session["user"] = u;
        //            return View();
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("Account", "Account does not exist!");
        //        }
        //    }

        //    return View();
        //}

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}