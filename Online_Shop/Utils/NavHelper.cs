using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Shop.Utils
{
    public class NavHelper
    {
        public static List<Category> GetCategories()
        {
            return new ShopEntities().Categories.ToList();
        }
        public static List<string> GetManufacturers()
        {
            return new ShopEntities().Specs.Select(m => m.Manufacturer).ToList();
        }
    }
}