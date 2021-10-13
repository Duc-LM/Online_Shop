using Online_Shop.Controllers;
using Online_Shop.Models;
using System.Linq;
using System.Web.Mvc;

namespace Online_Shop.Areas.Admin.Controllers
{
    public class SpecController : BaseController
    {
        // GET: Admin/Spec
        public ActionResult ShowSpec(int productId)
        {
            Spec spec = db.Specs.FirstOrDefault(s => s.Product_id == productId);
            return View(spec);
        }


    }
}