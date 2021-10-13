using Online_Shop.Models;
using System.Web.Mvc;

namespace Online_Shop.Controllers
{
    public class BaseController : Controller
    {
        protected ShopEntities db = new ShopEntities();

    }
}