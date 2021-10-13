using Online_Shop.Controllers;
using System.Web.Mvc;

namespace Online_Shop.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}