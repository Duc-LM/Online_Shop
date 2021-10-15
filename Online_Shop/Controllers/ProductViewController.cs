using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Shop.Controllers
{
    public class ProductViewController : BaseController
    {
        // GET: ProductView
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dell()
        {
            Product product = new Product();
            return View();
        }
    }
}