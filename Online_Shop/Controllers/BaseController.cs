using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Shop.Controllers
{
    public class BaseController : Controller
    {
        public static ShopEntities db = new ShopEntities();
      
    }
}