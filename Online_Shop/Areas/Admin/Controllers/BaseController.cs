using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Online_Shop.Areas.Admin.Controllers
{
    [SessionAuthorize]
    public class BaseController : Controller
    {
        protected ShopEntities db = new ShopEntities();
       
    }
}